using IkinciElAracIhaleSistemi.DAL.DAL;
using IkinciElAracIhaleSistemi.Entities.VM;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IkinciElAracIhaleSistemi.UI.Controllers
{
	[AllowAnonymous]
    public class GirisController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
			GirisVM vm = new GirisVM();

			if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");
			
			if (Request.Cookies["kullaniciBilgileri"] != null)
			{
				var httpCookie = Request.Cookies["kullaniciBilgileri"];
				vm.KullaniciAdi = httpCookie.Values["kullaniciadi"];
			}
			return View(vm);
		}

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(GirisVM girisVm)
        {
	        KullaniciDAL kullaniciDal = new KullaniciDAL();
	        var kullanici = kullaniciDal.KullaniciKontrol(girisVm);

	        if (kullanici == null)
	        {
		        ViewBag.HataMesaji = "Kullanıcı adı veya şifre hatalı";
		        return View("Index");
	        }
	        FormsAuthentication.SetAuthCookie(kullanici.KullaniciAdi, true);

	        HttpCookie cookie = new HttpCookie("kullaniciBilgileri");
	        if (girisVm.BeniHatirla)
	        {
		        cookie.Expires = DateTime.Now.AddDays(1);
		        cookie.Values.Add("kullaniciadi", girisVm.KullaniciAdi);
		        HttpContext.Response.Cookies.Add(cookie);
	        }

	        Session.Add("girisYapanKullanici", kullanici);
			return RedirectToAction("Index", "Home");
        }
        public ActionResult LogOut()
        {
	        FormsAuthentication.SignOut();
	        return RedirectToAction("Index", "Giris");
        }
	}
}