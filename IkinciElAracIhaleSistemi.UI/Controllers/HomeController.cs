using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IkinciElAracIhaleSistemi.DAL.DAL;
using IkinciElAracIhaleSistemi.Entities.VM;

namespace IkinciElAracIhaleSistemi.UI.Controllers
{
	public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
	        if ((Session["girisYapanKullanici"] as KullaniciRolVM) != null)
	        {
		        KullaniciRolVM kullanici = (Session["girisYapanKullanici"] as KullaniciRolVM);
				List<RolSayfaVM> listMenu = new RolSayfaDAL().RoleGoreSayfaYetkileriniGetir((Session["girisYapanKullanici"] as KullaniciRolVM).RolId);
				ViewBag.Menu = listMenu;
				ViewBag.GirisYapanKullanici = kullanici;
				return View();
			}
	        return RedirectToAction("Index", "Login");
        }
        public PartialViewResult PartialFooter()
        {
	        return PartialView();
        }
    }
}