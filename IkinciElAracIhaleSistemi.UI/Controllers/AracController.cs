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
			AracDAL arac = new AracDAL();
			ViewBag.Araclar = arac.AraclariGetir();
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
				AracDAL aracDal = new AracDAL();
				aracDal.AracEkle(arac);
				return RedirectToAction("Index");
			}

			return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		}
		[HttpGet]
		public ActionResult AracGuncelle(int id)
		{
			AracOzellikleriCache();
			AracStatuDAL aracStatu = new AracStatuDAL();
			ViewBag.AracStatuleri = aracStatu.StatuleriGetir(id);
			AracTramerDetayDAL aracTramer = new AracTramerDetayDAL();
			ViewBag.AracTramerDetaylari = aracTramer.TramerDetaylariniGetir(id);
			AracDAL aracDal = new AracDAL();
			var arac = aracDal.GuncellenecekAracBilgisiniGetir(id);
			return View(arac);
		}

		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult AracGuncelle([Bind(Exclude = "Fotograf")]AracEklemeDetayVM arac)
		{
			arac.ModifiedBy = (Session["girisYapanKullanici"] as KullaniciRolVM).KullaniciId;
			AracDAL aracDal = new AracDAL();
			aracDal.AracGuncelle(arac);
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
		public ActionResult IlanEkle([Bind(Include = "AracId, IlanBasligi, IlanAciklama")] AracIlanVM ilanVm)
		{
			IlanDAL ilan = new IlanDAL();
			ilan.IlanEkle(ilanVm);
			return RedirectToAction("Index");
		}
		public ActionResult IlanModal(int aracId)
		{
			var model = new AracIlanVM { AracId = aracId };
			ViewBag.IlanModel = model;
			return PartialView("IlanModal");
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
			ViewBag.VitesTipleri = CacheHelper.GetOrSet("VitesTipleri", () => new AracOzellikDAL().AracOzellikleriniListeyeDonustur(AracOzellikleri.VitesTipi), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.GovdeTipleri = CacheHelper.GetOrSet("GovdeTipleri", () => new AracOzellikDAL().AracOzellikleriniListeyeDonustur(AracOzellikleri.GovdeTipi), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.YakitTipleri = CacheHelper.GetOrSet("YakitTipleri", () => new AracOzellikDAL().AracOzellikleriniListeyeDonustur(AracOzellikleri.YakitTipi), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.VersiyonTipleri = CacheHelper.GetOrSet("VersiyonTipleri", () => new AracOzellikDAL().AracOzellikleriniListeyeDonustur(AracOzellikleri.Versiyon), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.Renkler = CacheHelper.GetOrSet("Renkler", () => new AracOzellikDAL().AracOzellikleriniListeyeDonustur(AracOzellikleri.Renk), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.Donanimlar = CacheHelper.GetOrSet("Donanim", () => new AracOzellikDAL().AracOzellikleriniListeyeDonustur(AracOzellikleri.OpsiyonelDonanim), DateTimeOffset.Now.AddMinutes(30));
			
			ViewBag.Firmalar = CacheHelper.GetOrSet("Firmalar", () => new FirmaDAL().FirmaListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.BireyselUyeler = CacheHelper.GetOrSet("BireyselUyeler", () => new BireyselUyeDAL().BireyselUyeleriListeyeDonustur(UyeTurleri.Bireysel), DateTimeOffset.Now.AddMinutes(30));
			
			AracListelemeOzellikleriCache();
		}

		public void AracListelemeOzellikleriCache()
		{
			ViewBag.AracTurleri = CacheHelper.GetOrSet("AracTurleri", () => new AracOzellikDAL().AracOzellikleriniListeyeDonustur(AracOzellikleri.AracTuru), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.Modeller = CacheHelper.GetOrSet("Modeller", () => new ModelDAL().ModelListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.Markalar = CacheHelper.GetOrSet("Markalar", () => new MarkaDAL().MarkaListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
			ViewBag.Statuler = CacheHelper.GetOrSet("Statuler", () => new StatuDAL().StatuListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
		}

	}
}