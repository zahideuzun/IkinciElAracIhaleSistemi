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
                //todo giren her kullanici dashboardda satis bilgilerini falan görmesin
				return View();
			}
	        
        }
        public PartialViewResult PartialFooter()
        {
	        return PartialView();
        }
    }
}