using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.DAL;
using WebApi.DAL.Interfaces;
using WebApi.Extensions;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/cart")]
    public class CartApiController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartApiController()
        {
            _unitOfWork = new UnitOfWork();
        }

        [Route("getall")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetCart()
        {
           var carts = _unitOfWork.CartRepo.GetAll();

            //Mapping list by extension method
            var cartList = carts.Select(c => c.MapCartToModel()).ToList();
            //mapping List by Anonymous object
            var cartItems = carts.Select(c => new
            {
                c.Id,
                c.Product?.PName,
                c.Quantity
            }).ToList();
            return Ok(cartItems);
        }


        [Route("AddItems")]
        [HttpPost]
        //[Authorize]
        public IHttpActionResult AddItems([FromBody] Order order)
        {
            var rand = RandomGen.Next();

            _unitOfWork.OrderRepo.Insert(new Order
            {
                OrderNumber=rand,
                UId=order.UId,
                OrderDate= System.DateTime.Now,
                Status=order.Status,    
                TotalAmount=order.TotalAmount,
                OrderDetails=order.OrderDetails
            });

            _unitOfWork.Save();
            return Ok();
        }

    }
}
