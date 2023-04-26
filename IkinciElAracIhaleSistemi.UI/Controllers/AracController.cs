using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IkinciElAracIhaleSistemi.DAL.DAL;

namespace IkinciElAracIhaleSistemi.UI.Controllers
{
    public class AracController : Controller
    {
        // GET: Arac
        public ActionResult Index()
        {

	        ViewBag.Araclar = new AracDAL().AraclariGetir();
			return View();
        }
        [HttpGet]
        public ActionResult AracEkle()
        {

            return View();
        }
    }
}