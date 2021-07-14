using OnlineStore.DAL;
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
using OnlineStore.Enums;

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

        [Authorize(Roles = UserRole.Admin)]
        public ActionResult Create()
        {
            
            return View();
        }

        [Authorize(Roles = UserRole.Admin)]
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
                PImage = "Images/" + file.FileName,
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


        public ActionResult Checkout()
        {
            CartViewModels model = GetProductsFromCookies();
            Session["Products"] = model;
            return PartialView(model);
        }

        private CartViewModels GetProductsFromCookies()
        {
            CartViewModels model = new CartViewModels();

            var CartProductsCookie = Request.Cookies["CartProducts"];

            if (CartProductsCookie != null)
            {
                model.CartProductIDS = CartProductsCookie.Value.Split('-').Where(x => x != "").Select(x => int.Parse(x)).ToList();
                model.UserCartProducts = GetProductsByIds(model.CartProductIDS);
            }
            return model;
        }

        public List<Product> GetProductsByIds(List<int> IDs)
        {
            return _unitOfWork.ProductRepo.Get(product => IDs.Contains(product.Id)).ToList();
        }


        public ActionResult CheckoutProcedure()
        {
            CartViewModels model = GetProductsFromCookies();
            return View(model);
        }
    }
}