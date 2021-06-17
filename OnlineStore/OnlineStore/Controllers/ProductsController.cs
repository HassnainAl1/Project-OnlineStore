﻿using OnlineStore.DAL;
using OnlineStore.DAL.Interfaces;
using OnlineStore.Models;
using PagedList;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Models.WebModels;

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
            PagedList<Product> model= new PagedList<Product>(products, page, 6);
            return View(model);
        }

        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductModel data, HttpPostedFileBase file)
        {
           var folderPath = Path.Combine(Server.MapPath("~/Images"));
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(file.FileName));
            file.SaveAs(path);

            data.CreatedDate = DateTime.Now;
            _unitOfWork.ProductRepo.Insert(new Product
            {
                PName = data.PName,
                PurchasePrice = data.PurchasePrice,
                Description = data.Description,
                SellPrice = data.SellPrice,
                PImage = "~/Images/" + file.FileName,
                CreatedDate = data.CreatedDate
            });
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