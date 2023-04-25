using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IkinciElAracIhaleSistemi.DAL.DAL;
using IkinciElAracIhaleSistemi.Entities.VM;

namespace IkinciElAracIhaleSistemi.UI.Controllers
{
    [Authorize]
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
			ViewBag.RolId = new SelectList(new RolDAL().RolleriGetir(),"Id", "RolAdi");
			return View();
		}

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult KullaniciEkle([Bind(Include = "KullaniciIsim, KullaniciSoyisim, KullaniciAdi, KullaniciSifre, KullaniciTelefon, KullaniciMail,RolId")] KullaniciRolVM kullanici)
        {
	        if (new KullaniciDAL().KullaniciEkle(kullanici) > 0 && ModelState.IsValid) return RedirectToAction("Index");

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
            [Bind(Include = "KullaniciIsim, KullaniciSoyisim, KullaniciAdi, KullaniciSifre, KullaniciTelefon, KullaniciMail,RolId")] KullaniciRolVM kullanici)
        {
			if (new KullaniciDAL().KullaniciGuncelle(kullanici) > 0 && ModelState.IsValid) return RedirectToAction("KullaniciGuncelle");

			ViewBag.RolId = new SelectList(new RolDAL().RolleriGetir(), "Id", "RolAdi", kullanici.RolId);
	        return View(kullanici);
		}

        public ActionResult KullaniciSil(KullaniciRolVM kullanici)
        {
	        if (new KullaniciDAL().KullaniciGuncelle(kullanici) > 0)
	        {
		        return RedirectToAction("Index");
	        }
	        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		}
	}
}