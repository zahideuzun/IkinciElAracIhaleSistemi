using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IkinciElAracIhaleSistemi.DAL.DAL;
using IkinciElAracIhaleSistemi.Entities.VM.Arac;

namespace IkinciElAracIhaleSistemi.UI.Controllers
{
    public class TramerController : Controller
    {
        // GET: Tramer
        public ActionResult Index()
        {
            AracTramerVM tramerVM = new AracTramerVM();
            AracParcaVM parcaVM = new AracParcaVM();
            AracParcaDAL aracParca = new AracParcaDAL();
            AracTramerDurumDAL aracTramer = new AracTramerDurumDAL();
            ViewBag.AracParcalari = aracParca.AracParcalariGetir();
            ViewBag.TramerDurumlari = aracTramer.AracTramerDurumlariniGetir();
            return View((tramerVM,parcaVM));
        }

        public ActionResult TramerEkle()
        {
	        return null;
        }
    }
}