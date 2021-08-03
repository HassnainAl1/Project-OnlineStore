using Microsoft.AspNet.Identity;
using OnlineStore.DAL;
using OnlineStore.DAL.Interfaces;
using OnlineStore.Helpers;
using OnlineStore.Models.WebModels;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
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

        public ActionResult Pay()
        {
            ViewBag.StripePublishKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            return View();
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
        public List<Models.Product> GetProductsByIds(List<int> IDs)
        {
            return _unitOfWork.ProductRepo.Get(product => IDs.Contains(product.Id)).ToList();
        }

        [HttpPost]
        public ActionResult Charge(long totalPrice,string stripeToken, string stripeEmail)
       
        {
            Stripe.StripeConfiguration.SetApiKey(ConfigurationManager.AppSettings["stripePublishableKey"]);
            Stripe.StripeConfiguration.ApiKey = ConfigurationManager.AppSettings["stripeSecretKey"];

            var myCharge = new Stripe.ChargeCreateOptions();

            // always set these properties
            myCharge.Amount = totalPrice;
            myCharge.Currency = "USD";

            myCharge.ReceiptEmail = stripeEmail;
            myCharge.Description = "Sample Charge";
            myCharge.Source = stripeToken;
            myCharge.Capture = true;

            var chargeService = new Stripe.ChargeService();
            Charge stripeCharge = chargeService.Create(myCharge);

           var cartViewModel =  GetProductsFromCookies();
            return View("PaymentStatus", cartViewModel);
        }

        public ActionResult PaymentStatus()
        {
            return View();
        }
    }
}