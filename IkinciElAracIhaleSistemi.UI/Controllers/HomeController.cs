using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IkinciElAracIhaleSistemi.DAL.DAL;
using IkinciElAracIhaleSistemi.Entities.VM;

namespace IkinciElAracIhaleSistemi.UI.Controllers
{
	public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
	        {
				return View();
			}
	        
        }
        public PartialViewResult PartialFooter()
        {
	        return PartialView();
        }
    }
}