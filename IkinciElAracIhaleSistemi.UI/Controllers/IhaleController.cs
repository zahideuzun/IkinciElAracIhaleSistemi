using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IkinciElAracIhaleSistemi.App.Helper;
using IkinciElAracIhaleSistemi.DAL.DAL;
using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemi.Entities.VM;
using IkinciElAracIhaleSistemi.Entities.VM.Enum;

namespace IkinciElAracIhaleSistemi.UI.Controllers
{
    public class IhaleController : Controller
    {
        // GET: Ihale
        public ActionResult Index()
        {
            ViewBag.Statuler = CacheHelper.GetOrSet("Statuler", () => new IhaleDAL().StatuListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
            ViewBag.IhaleTurleri = CacheHelper.GetOrSet("IhaleTurleri", () => new IhaleDAL().IhaleTuruListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
            return View(new IhaleDAL().IhaleleriGetir());
        }
        [HttpGet]
        public ActionResult IhaleEkle()
        {
            ViewBag.Statuler = CacheHelper.GetOrSet("Statuler", () => new IhaleDAL().StatuListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
            ViewBag.Firmalar = CacheHelper.GetOrSet("Firmalar", () => new FirmaDAL().FirmaListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
            ViewBag.BireyselUyeler = CacheHelper.GetOrSet("BireyselUyeler", () => new BireyselUyeDAL().BireyselUyeleriListeyeDonustur(UyeTurleri.Bireysel), DateTimeOffset.Now.AddMinutes(30));
            ViewBag.IhaleTurleri = CacheHelper.GetOrSet("IhaleTurleri", () => new IhaleDAL().IhaleTuruListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
            return View();
        }
        [HttpPost]
        public ActionResult IhaleEkle(IhaleEkleVM ihaleEkle)
        {
            if (ModelState.IsValid)
            {
                //ihaleEkle.CreatedBy = (Session["girisYapanKullanici"] as KullaniciRolVM).KullaniciId;
                new IhaleDAL().IhaleEkle(ihaleEkle);
                return RedirectToAction("Index");
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return View();
        }
    }
}