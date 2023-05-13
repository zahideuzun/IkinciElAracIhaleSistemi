using IkinciElAracIhaleSistemi.App.Helper;
using IkinciElAracIhaleSistemi.DAL.DAL;
using IkinciElAracIhaleSistemi.Entities.VM;
using IkinciElAracIhaleSistemi.Entities.VM.Arac;
using IkinciElAracIhaleSistemi.Entities.VM.Enum;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web.Mvc;

namespace IkinciElAracIhaleSistemi.UI.Controllers
{
	public class AracController : Controller
	{
		// GET: Arac
		public ActionResult Index()
		{
			AracListelemeOzellikleriCache();
            ViewBag.Araclar = new AracDAL().AraclariGetir();
			return View();
		}
		[HttpGet]
		public ActionResult AracEkle()
		{
            AracOzellikleriCache();
			return View();
		}
		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult AracEkle([Bind(Exclude = "Fotograf, AracId")] AracEklemeDetayVM arac)
		{
			if (ModelState.IsValid)
			{
				arac.CreatedBy = (Session["girisYapanKullanici"] as KullaniciRolVM).KullaniciId;
                new AracDAL().AracEkle(arac);
				return RedirectToAction("Index");
			}

			return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		}
		[HttpGet]
		public ActionResult AracGuncelle(int id)
		{
			AracOzellikleriCache();
            ViewBag.AracStatuleri = new AracStatuDAL().StatuleriGetir(id);
            ViewBag.AracTramerDetaylari = new AracTramerDetayDAL().TramerDetaylariniGetir(id);
            var arac = new AracDAL().GuncellenecekAracBilgisiniGetir(id);
			return View(arac);
		}

		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult AracGuncelle(/*[Bind(Exclude = "Fotograf")]*/AracEklemeDetayVM arac)
		{
			arac.ModifiedBy = (Session["girisYapanKullanici"] as KullaniciRolVM).KullaniciId;
            new AracDAL().AracGuncelle(arac);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult AracSil(int id)
		{
			AracDAL aracDal = new AracDAL();
			aracDal.AracSil(id);
			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult IlanEkle([Bind(Include = "AracId, Baslik, Aciklama")] AracIlanVM ilanVm)
		{
			IlanDAL ilan = new IlanDAL();
			ilan.IlanEkle(ilanVm);
			return RedirectToAction("Index");
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

		/// <summary>
		/// araca ait ozellikleri cache ekleyen metotlar
		/// </summary>
		public void AracOzellikleriCache()
		{
			ViewBag.VitesTipleri = CacheHelper.GetOrSet("VitesTipleri", () => new AracOzellikDAL().AracOzellikleriniListeyeDonustur((int)AracOzellikleri.VitesTipi), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.GovdeTipleri = CacheHelper.GetOrSet("GovdeTipleri", () => new AracOzellikDAL().AracOzellikleriniListeyeDonustur((int)AracOzellikleri.GovdeTipi), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.YakitTipleri = CacheHelper.GetOrSet("YakitTipleri", () => new AracOzellikDAL().AracOzellikleriniListeyeDonustur((int)AracOzellikleri.YakitTipi), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.VersiyonTipleri = CacheHelper.GetOrSet("VersiyonTipleri", () => new AracOzellikDAL().AracOzellikleriniListeyeDonustur((int)AracOzellikleri.Versiyon), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.Renkler = CacheHelper.GetOrSet("Renkler", () => new AracOzellikDAL().AracOzellikleriniListeyeDonustur((int)AracOzellikleri.Renk), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.Donanimlar = CacheHelper.GetOrSet("Donanim", () => new AracOzellikDAL().AracOzellikleriniListeyeDonustur((int)AracOzellikleri.OpsiyonelDonanim), DateTimeOffset.Now.AddMinutes(30));
			
			ViewBag.Firmalar = CacheHelper.GetOrSet("Firmalar", () => new FirmaDAL().FirmaListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.BireyselUyeler = CacheHelper.GetOrSet("BireyselUyeler", () => new BireyselUyeDAL().BireyselUyeleriListeyeDonustur(UyeTurleri.Bireysel), DateTimeOffset.Now.AddMinutes(30));
			
			AracListelemeOzellikleriCache();
		}

		public void AracListelemeOzellikleriCache()
		{
			ViewBag.AracTurleri = CacheHelper.GetOrSet("AracTurleri", () => new AracOzellikDAL().AracOzellikleriniListeyeDonustur((int)AracOzellikleri.AracTuru), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.Modeller = CacheHelper.GetOrSet("Modeller", () => new ModelDAL().ModelListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.Markalar = CacheHelper.GetOrSet("Markalar", () => new MarkaDAL().MarkaListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.Statuler = CacheHelper.GetOrSet("Statuler", () => new StatuDAL().StatuListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
		}

	}
}