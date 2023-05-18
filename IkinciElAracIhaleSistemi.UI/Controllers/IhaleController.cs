﻿using System;
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
            IhaleCacheListeleri();
            return View(new IhaleDAL().IhaleleriGetir());
        }
        [HttpGet]
        public ActionResult IhaleEkle()
        {
            IhaleCacheListeleri();
            return View();
        }
        [HttpPost]
        public ActionResult IhaleEkle([Bind(Include = "IhaleAdi, IhaleTuruId, BireyselveyaFirmaId, BaslangicTarihi, BaslangicSaati, BitisTarihi, BitisSaati, StatuId")] IhaleEkleVM ihaleEkle)
        {
            if (ModelState.IsValid && ihaleEkle != null)
            {
                new IhaleDAL().IhaleEkle(ihaleEkle);
                return RedirectToAction("Index");
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        [HttpGet]
        public ActionResult IhaleDetay(int? id)
        {
            if (id != null)
            {
                IhaleCacheListeleri();
                ViewBag.FirmaListesi = new IhaleDAL().FirmayaAitAracListesineDonustur(id);
                ViewBag.IhaledekiAracListesi = new IhaleDAL().IhaledekiAraclariGetir(id);
                var ihale = new IhaleDAL().IdyeGoreIhaleBilgileriniGetir(id);
                return View(ihale);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        [HttpPost]
        public ActionResult IhaleDetay(IhaleEkleVM ihale)
        {
            if (ModelState.IsValid && ihale != null)
            {
                IhaleCacheListeleri();
                new IhaleDAL().IhaleBilgileriniGuncelle(ihale);
                return RedirectToAction("Index");
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        
        [HttpPost]
        public ActionResult IhaleyeAracEkle(List<IhaleEkleVM> ihale)
        {
            if (ModelState.IsValid && ihale != null)
            {
                new IhaleDAL().IhaleyeAracEkle(ihale);
                int ihaleId = ihale[0].IhaleId;
                return RedirectToAction("IhaleDetay", "Ihale", new { id = ihaleId});
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public void IhaleCacheListeleri()
        {
            ViewBag.Statuler = CacheHelper.GetOrSet("Statuler", () => new IhaleDAL().StatuListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));

            ViewBag.Firmalar = CacheHelper.GetOrSet("Firmalar", () => new FirmaDAL().FirmaListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
            ViewBag.BireyselUyeler = CacheHelper.GetOrSet("BireyselUyeler", () => new BireyselUyeDAL().BireyselUyeleriListeyeDonustur(UyeTurleri.Bireysel), DateTimeOffset.Now.AddMinutes(30));
            ViewBag.IhaleTurleri = CacheHelper.GetOrSet("IhaleTurleri", () => new IhaleDAL().IhaleTuruListesineDonustur(), DateTimeOffset.Now.AddMinutes(30));
        }
    }
}