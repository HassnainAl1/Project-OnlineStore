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
    
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public HomeController()
        {
            _unitOfWork = new UnitOfWork();
        }



        public ActionResult Index()
        {
            var name = User.Identity.Name;
            var userId = User.Identity.GetUserId();
            var userEmail = User.Identity.GetClaimValue(ClaimTypes.Email);
            DateTime currentDate = DateTime.Now;
            var today = currentDate;
            var lastWeek = currentDate.AddDays(-7);
            //var thisWeekStart = currentDate.AddDays(-(int)currentDate.DayOfWeek);
            //var thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1);
            //var lastWeekStart = thisWeekStart.AddDays(-7);
            //var lastWeekEnd = thisWeekStart.AddSeconds(-1);


            var latestProducts = _unitOfWork.ProductRepo.Get(p => p.CreatedDate >= lastWeek && p.CreatedDate <= today, p => p.OrderByDescending(x => x.CreatedDate));
            return View(latestProducts);
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