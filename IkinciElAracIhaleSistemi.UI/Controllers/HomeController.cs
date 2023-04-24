using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IkinciElAracIhaleSistemi.DAL.DAL;
using IkinciElAracIhaleSistemi.Entities.VM;

namespace IkinciElAracIhaleSistemi.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialSideBar()
        {
	        //int kullaniciId = (Session["girisYapanKullanici"] as KullaniciRolVM).RolId;
	        List<RolSayfaVM> listMenu = new RolSayfaDAL().RoleGoreSayfaYetkileriniGetir((Session["girisYapanKullanici"] as KullaniciRolVM).RolId);
	        ViewBag.Menu = listMenu;
            ViewBag.GirisYapanKullanici = (Session["girisYapanKullanici"] as KullaniciRolVM).KullaniciIsim;
			return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
	        return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
	        return PartialView();
        }
	}
}