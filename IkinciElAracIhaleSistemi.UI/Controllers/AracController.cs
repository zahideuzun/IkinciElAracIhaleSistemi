using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IkinciElAracIhaleSistemi.App.Helper;
using IkinciElAracIhaleSistemi.DAL.DAL;
using IkinciElAracIhaleSistemi.Entities.VM;
using IkinciElAracIhaleSistemi.Entities.VM.Arac;
using IkinciElAracIhaleSistemi.Entities.VM.Enum;

namespace IkinciElAracIhaleSistemi.UI.Controllers
{
    public class AracController : Controller
    {
        // GET: Arac
        public ActionResult Index()
        {
			ViewBag.AracTurleri = CacheHelper.GetOrSet("AracTurleri", () => new AracOzellikDAL().AracOzellikleriniListeyeDonustur(AracOzellikleri.AracTuru), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.Modeller = CacheHelper.GetOrSet("Modeller", () => new ModelDAL().ModelListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.Markalar = CacheHelper.GetOrSet("Markalar", () => new MarkaDAL().MarkaListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.Statuler = CacheHelper.GetOrSet("Statuler", () => new StatuDAL().StatuListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.Araclar = new AracDAL().AraclariGetir();
			return View();
        }
        [HttpGet]
        public ActionResult AracEkle()
        {
	        ViewBag.VitesTipleri = CacheHelper.GetOrSet("VitesTipleri", () => new AracOzellikDAL().AracOzellikleriniListeyeDonustur(AracOzellikleri.VitesTipi), DateTimeOffset.Now.AddMinutes(30));
	        ViewBag.GovdeTipleri = CacheHelper.GetOrSet("GovdeTipleri", () => new AracOzellikDAL().AracOzellikleriniListeyeDonustur(AracOzellikleri.GovdeTipi), DateTimeOffset.Now.AddMinutes(30));
	        ViewBag.YakitTipleri = CacheHelper.GetOrSet("YakitTipleri", () => new AracOzellikDAL().AracOzellikleriniListeyeDonustur(AracOzellikleri.YakitTipi), DateTimeOffset.Now.AddMinutes(30));
	        ViewBag.VersiyonTipleri = CacheHelper.GetOrSet("VersiyonTipleri", () => new AracOzellikDAL().AracOzellikleriniListeyeDonustur(AracOzellikleri.Versiyon), DateTimeOffset.Now.AddMinutes(30));
	        ViewBag.Renkler = CacheHelper.GetOrSet("Renkler", () => new AracOzellikDAL().AracOzellikleriniListeyeDonustur(AracOzellikleri.Renk), DateTimeOffset.Now.AddMinutes(30));
	        ViewBag.Donanimlar = CacheHelper.GetOrSet("Donanim", () => new AracOzellikDAL().AracOzellikleriniListeyeDonustur(AracOzellikleri.OpsiyonelDonanim), DateTimeOffset.Now.AddMinutes(30));
	        ViewBag.AracTurleri = CacheHelper.GetOrSet("AracTurleri", () => new AracOzellikDAL().AracOzellikleriniListeyeDonustur(AracOzellikleri.AracTuru), DateTimeOffset.Now.AddMinutes(30));
	        ViewBag.Modeller = CacheHelper.GetOrSet("Modeller", () => new ModelDAL().ModelListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
	        ViewBag.Markalar = CacheHelper.GetOrSet("Markalar", () => new MarkaDAL().MarkaListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
	        ViewBag.Statuler = CacheHelper.GetOrSet("Statuler", () => new StatuDAL().StatuListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
	        ViewBag.Firmalar = CacheHelper.GetOrSet("Firmalar", () => new FirmaDAL().FirmaListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
	        ViewBag.BireyselUyeler = CacheHelper.GetOrSet("BireyselUyeler", () => new BireyselUyeDAL().BireyselUyeleriListeyeDonustur(UyeTurleri.Bireysel), DateTimeOffset.Now.AddMinutes(30));

			return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult AracEkle([Bind(Exclude = "Fotograf, AracId")] AracEklemeDetayVM arac)
        {
	        
	       
			//todo bireysel ve kurumsal eklemeyi düzenle, guncellemeyi de yap ve artik bitir NOLUR!!!! 
			if (ModelState.IsValid)
			{
				if ( arac.AracId == 0) //kayitli bir arac yoksa ekleme islemi
				{
					arac.CreatedBy = (Session["girisYapanKullanici"] as KullaniciRolVM).KullaniciId;
					AracDAL aracDal = new AracDAL();
					aracDal.AracEkle(arac);
					return RedirectToAction("Index");
				}
				else
				{
					arac.ModifiedBy = (Session["girisYapanKullanici"] as KullaniciRolVM).KullaniciId;
					AracDAL aracDal = new AracDAL();
					aracDal.AracGuncelle(arac);
					return RedirectToAction("Index");
				}
			}
			
	        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		}
        [HttpPost]
        public JsonResult ModelleriGetir(int markaId)
        {
	        List<ModelVM> modeller = new ModelDAL().MarkayaGoreModelleriGetir(markaId); 
		        var modelList = new List<SelectListItem>();
	        foreach (var model in modeller)
	        {
		        modelList.Add(new SelectListItem() { Text = model.ModelAdi, Value = model.ModelId.ToString() });
	        }
	        return Json(modelList);
        }
        



	}
}