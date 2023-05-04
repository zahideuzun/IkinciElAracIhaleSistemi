using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IkinciElAracIhaleSistemi.DAL.DAL;

namespace IkinciElAracIhaleSistemi.UI.Controllers
{
    public class IlanController : Controller
    {
        // GET: Ilan
        public ActionResult Index()
        {
	        var ilanlar = new IlanDAL().AktifIlanlariGetir();
            return View(ilanlar);
        }
    }
}