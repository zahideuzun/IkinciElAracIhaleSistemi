using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IkinciElAracIhaleSistemi.App.Results;
using IkinciElAracIhaleSistemi.DAL.DAL;
using IkinciElAracIhaleSistemi.Entities.VM;

namespace IkinciElAracIhaleSistemi.UI.Controllers
{
	//[Authorize]
	public class KullaniciController : Controller
	{
		// GET: Kullanici
		public ActionResult Index()
		{
			return View(new KullaniciDAL().KullanicilariRoluneGoreGetir());
		}

		[HttpGet]
		public ActionResult KullaniciEkle()
		{
			ViewBag.RolId = new SelectList(new RolDAL().RolleriGetir(), "Id", "RolAdi");
			return View();
		}

		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult KullaniciEkle([Bind(Include = "KullaniciIsim, KullaniciSoyisim, KullaniciAdi, KullaniciSifre, KullaniciTelefon, KullaniciMail,RolId")] KullaniciRolVM kullanici)
		{
			if (ModelState.IsValid && kullanici != null)
			{
				KullaniciDAL kullaniciDal = new KullaniciDAL();
				kullaniciDal.KullaniciEkle(kullanici);
				return RedirectToAction("Index");
			}

			return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		}

		[HttpGet]
		public ActionResult KullaniciGuncelle(int? id)
		{
			//todo hata mesaji duzenlenecek
			if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			KullaniciDAL kullaniciDal = new KullaniciDAL();
			var kullanici = kullaniciDal.IdyeGoreKullaniciGetir(id);

			if (kullanici == null) return HttpNotFound();

			ViewBag.RolId = new SelectList(new RolDAL().RolleriGetir(), "Id", "RolAdi", kullanici.RolId);
			return View(kullanici);
		}

		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult KullaniciGuncelle(
			[Bind(Include = "KullaniciId, KullaniciIsim, KullaniciSoyisim, KullaniciAdi, KullaniciSifre, KullaniciTelefon, KullaniciMail,RolId")] KullaniciRolVM kullanici)
		{

			if (ModelState.IsValid && kullanici != null)
			{
				KullaniciDAL kullaniciDal = new KullaniciDAL();
				kullaniciDal.KullaniciGuncelle(kullanici);
				ViewBag.RolId = new SelectList(new RolDAL().RolleriGetir(), "Id", "RolAdi", kullanici.RolId);
				return View(kullanici);
			}
			return RedirectToAction("Index");
		}

		public ActionResult KullaniciSil(int? id)
		{
			if (ModelState.IsValid && id != null)
			{
				KullaniciDAL kullaniciDal = new KullaniciDAL();
				kullaniciDal.KullaniciSil(id);
				return RedirectToAction("Index");
			}
			//todo hata mesaji duzenlenecek
			return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		}
	}
}