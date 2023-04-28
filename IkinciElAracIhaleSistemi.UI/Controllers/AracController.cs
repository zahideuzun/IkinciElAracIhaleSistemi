using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IkinciElAracIhaleSistemi.DAL.DAL;
using IkinciElAracIhaleSistemi.DAL.DAL.Metot;
using IkinciElAracIhaleSistemi.Entities.VM.Arac;
using IkinciElAracIhaleSistemi.Entities.VM.Enum;

namespace IkinciElAracIhaleSistemi.UI.Controllers
{
    public class AracController : Controller
    {
        // GET: Arac
        public ActionResult Index()
        {
			ViewBag.AracTurleri = CacheHelper.GetOrSet("AracTurleri", () => new AracOzellikDAL().AracTuruListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.Modeller = CacheHelper.GetOrSet("Modeller", () => new ModelDAL().ModelListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.Markalar = CacheHelper.GetOrSet("Markalar", () => new MarkaDAL().MarkaListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.Statuler = CacheHelper.GetOrSet("Statuler", () => new StatuDAL().StatuListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.Araclar = new AracDAL().AraclariGetir();
			return View();
        }
        [HttpGet]
        public ActionResult AracEkle()
        {
			ViewBag.VitesTipleri = CacheHelper.GetOrSet("VitesTipleri", () => new AracOzellikDAL().VitesTipiListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.GovdeTipleri = CacheHelper.GetOrSet("GovdeTipleri", () => new AracOzellikDAL().GovdeTipiListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.YakitTipleri = CacheHelper.GetOrSet("YakitTipleri", () => new AracOzellikDAL().YakitTipiListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.VersiyonTipleri = CacheHelper.GetOrSet("VersiyonTipleri", () => new AracOzellikDAL().VersiyonListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.Renkler = CacheHelper.GetOrSet("Renkler", () => new AracOzellikDAL().RenkListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.Donanim = CacheHelper.GetOrSet("Donanim", () => new AracOzellikDAL().DonanimTipiListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.AracTurleri = CacheHelper.GetOrSet("AracTurleri", () => new AracOzellikDAL().AracTuruListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.Modeller = CacheHelper.GetOrSet("Modeller", () => new ModelDAL().ModelListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.Markalar = CacheHelper.GetOrSet("Markalar", () => new MarkaDAL().MarkaListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.Statuler = CacheHelper.GetOrSet("Statuler", () => new StatuDAL().StatuListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.Statuler = CacheHelper.GetOrSet("Firmalar", () => new FirmaDAL().FirmaListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));

			return View();
        }
        [HttpPost]
        public ActionResult AracEkle(AracEklemeDetayVM arac)
        {
	        
	        return View();
        }
	}
}