using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_App.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var cookies = HttpContext.Request.Cookies;
			return View();
		}

		public ActionResult TestAction1()
		{
			string name = "Alex";

			ViewBag.Name = name;
			ViewData["Name"] = name + " view data";
			TempData["Name"] = name + " temp data";

			Response.Write("Hey it's a response");
			
			return View("TestAction1");
		}

		public ActionResult RedirectToUrl()
		{
			return Redirect("http://google.com");
		}

		public ActionResult RedirectToContact()
		{
			HttpContext.Response.SetCookie(new HttpCookie("CookieName", "CookieValue"));
			return RedirectToAction("Contact");
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}