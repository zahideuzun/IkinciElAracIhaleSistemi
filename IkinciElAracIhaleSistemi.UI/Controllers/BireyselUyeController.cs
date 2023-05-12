using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IkinciElAracIhaleSistemi.DAL.Configuration;
using IkinciElAracIhaleSistemi.DAL.DAL;
using IkinciElAracIhaleSistemi.Entities.VM;

namespace IkinciElAracIhaleSistemi.UI.Controllers
{
    public class BireyselUyeController : Controller
    {
        // GET: BireyselUye
        public ActionResult Index()
        {
            return View(new BireyselUyeDAL().BireyselUyeleriListele());
        }
        [HttpGet]
        public ActionResult UyeOnay(int id)
        {
            BireyselUyeDAL dal = new BireyselUyeDAL();
            dal.BireyselUyeOnay(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult BireyselUyeEkle()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult BireyselUyeEkle([Bind(Include = "Isim, Soyisim, Sifre, Telefon, Mail,TcKimlik")] BireyselUyeVM bireyselUye)
        {
            if (ModelState.IsValid && bireyselUye != null)
            {
                BireyselUyeDAL bireyselUyeDal = new BireyselUyeDAL();
                bireyselUyeDal.BireyselUyeEkle(bireyselUye);
                return RedirectToAction("Index");
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        public ActionResult BireyselUyeGuncelle(int? id)
        {
            //todo hata mesaji duzenlenecek
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            BireyselUyeDAL bireyselUyeDal = new BireyselUyeDAL();
            var bireyselUye = bireyselUyeDal.IdyeGoreBireyselUyeGetir(id);

            if (bireyselUye == null) return HttpNotFound();

            return View(bireyselUye);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult BireyselUyeGuncelle(
            [Bind(Include = "UyeId, Isim, Soyisim,  Sifre, Telefon, Mail")] BireyselUyeVM bireyselUye)
        {

            if (ModelState.IsValid && bireyselUye != null)
            {
                BireyselUyeDAL bireyselUyeDal = new BireyselUyeDAL();
                bireyselUyeDal.BireyselUyeGuncelle(bireyselUye);
                return View(bireyselUye);
            }
            return RedirectToAction("Index");
        }

        public ActionResult BireyselUyeSil(int? id)
        {
            if (ModelState.IsValid && id != null)
            {
                BireyselUyeDAL bireyselUyeDal = new BireyselUyeDAL();
                bireyselUyeDal.BireyselUyeSil(id);
                return RedirectToAction("Index");
            }
            //todo hata mesaji duzenlenecek
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}