using OnlineStore.DAL;
using OnlineStore.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            DateTime currentDate = DateTime.Now;
            var today = currentDate;
            var lastWeek = currentDate.AddDays(-7);
            //var thisWeekStart = currentDate.AddDays(-(int)currentDate.DayOfWeek);
            //var thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1);
            //var lastWeekStart = thisWeekStart.AddDays(-7);
            //var lastWeekEnd = thisWeekStart.AddSeconds(-1);


            var latestProducts = _unitOfWork.ProductRepo.Get(p => p.CreatedDate >= lastWeek && p.CreatedDate <= today);
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