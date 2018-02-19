using ElectronicShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicShop.Controllers
{
    public class HomeController : Controller
    {
        private ElectronicShopContext _shopContext = new ElectronicShopContext();

        public ActionResult Index()
        {
            return View(_shopContext.Phones);
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

        protected override void Dispose(bool disposing)
        {
            _shopContext.Dispose();
            base.Dispose(disposing);
        }
    }
}