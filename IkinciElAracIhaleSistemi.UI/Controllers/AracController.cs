using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IkinciElAracIhaleSistemi.DAL.DAL;
using IkinciElAracIhaleSistemi.Entities.VM.Arac;
using IkinciElAracIhaleSistemi.Entities.VM.Enum;

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
	        ViewBag.VitesTipleri = new AracOzellikDAL().VitesTipiListesineDonustur();
            ViewBag.GovdeTipleri = new AracOzellikDAL().GovdeTipiListesineDonustur();
            ViewBag.YakitTipleri = new AracOzellikDAL().YakitTipiListesineDonustur();
            ViewBag.VersiyonTipleri = new AracOzellikDAL().VersiyonListesineDonustur();
            ViewBag.Renkler = new AracOzellikDAL().RenkListesineDonustur();
            ViewBag.Donanim = new AracOzellikDAL().DonanimTipiListesineDonustur();
            return View();
        }
        [HttpPost]
        public ActionResult AracEkle(AracEklemeDetayVM arac)
        {
	        
	        return View();
        }
	}
}