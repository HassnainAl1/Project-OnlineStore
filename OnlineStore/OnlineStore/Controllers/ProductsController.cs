using OnlineStore.DAL;
using OnlineStore.DAL.Interfaces;
using OnlineStore.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public ProductsController()
        {
            _unitOfWork = new UnitOfWork();
        }

        // GET: Products        
                                //(int page = 1)
        public ActionResult Index(int page = 1)
        {
            IEnumerable<Product> products = _unitOfWork.ProductRepo.Get();
            PagedList<Product> model= new PagedList<Product>(products, page, 5);
            return View(model);
        }

        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product data)
        {
            data.CreatedDate = DateTime.Now;
            _unitOfWork.ProductRepo.Insert(data);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var data =_unitOfWork.ProductRepo.GetById(id);
            return View(data);

        }

        public ActionResult Delete(int id)
        {
         
            _unitOfWork.ProductRepo.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var data = _unitOfWork.ProductRepo.GetById(id);
            return View(data);

        }

        [HttpPost]
        public ActionResult Edit(Product data)
        {
            _unitOfWork.ProductRepo.Update(data);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

    }
}