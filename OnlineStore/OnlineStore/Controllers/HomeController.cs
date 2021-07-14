using Microsoft.AspNet.Identity;
using OnlineStore.DAL;
using OnlineStore.DAL.Interfaces;
using OnlineStore.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    
    public class HomeController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;


        public HomeController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ActionResult SetCulture(string culture)
        {
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var name = User.Identity.Name;
            var userId = User.Identity.GetUserId();
            var userEmail = User.Identity.GetClaimValue(ClaimTypes.Email);

            //DateTime currentDate = DateTime.Now;
            //var today = currentDate;
            //var lastWeek = currentDate.AddDays(-7);
            //var latestProducts = _unitOfWork.ProductRepo.Get(p => p.CreatedDate >= lastWeek && p.CreatedDate <= today, p => p.OrderByDescending(x => x.CreatedDate));
            //return View(latestProducts);

            return View(_unitOfWork.ProductRepo.Get().OrderByDescending(x => x.CreatedDate).Take(5).ToList());

          
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}