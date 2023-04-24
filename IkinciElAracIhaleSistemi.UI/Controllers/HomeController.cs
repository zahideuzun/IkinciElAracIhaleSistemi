using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IkinciElAracIhaleSistemi.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialSideBar()
        {
	        return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
	        return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
	        return PartialView();
        }
	}
}