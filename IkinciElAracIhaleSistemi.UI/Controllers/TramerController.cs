using IkinciElAracIhaleSistemi.DAL.DAL;
using IkinciElAracIhaleSistemi.Entities.VM.Arac;
using System.Web.Mvc;

namespace IkinciElAracIhaleSistemi.UI.Controllers
{
	public class TramerController : Controller
    {
        // GET: Tramer
        public ActionResult Index(int id)
        {
	        AracTramerDetayEklemeVM detayEkleme = new AracTramerDetayEklemeVM();
			AracTramerDetayDAL aracTramer = new AracTramerDetayDAL();
            ViewBag.AracParcalari = aracTramer.AracParcalariGetir();
            ViewBag.TramerDurumlari = aracTramer.AracTramerDurumlariniGetir();
            return View((detayEkleme,id));
        }

        
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(AracTramerDetayEklemeVM aracTramer)
        {
	        AracTramerDetayDAL aracTramerDetay = new AracTramerDetayDAL();
	        aracTramerDetay.TramerEkle(aracTramer);
	        return RedirectToAction("Index", "Arac");
        }

        
	}
}