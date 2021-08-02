using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Extensions
{
    public static class CartExtensions
    {
        public static MyCartModel MapCartToModel(this Cart cart)
        {
            var model = new MyCartModel();
            model.CartId = cart.Id;
            return new MyCartModel
            {
               CartId = cart.Id,
               PName = cart.Product?.PName,
               PQuantity = cart.Quantity
            };
        }
    }
}