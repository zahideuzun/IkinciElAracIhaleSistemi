using IkinciElAracIhaleSistemi.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IkinciElAracIhaleSistemi.UI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
			LoginVM vm = new LoginVM();

			if (User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Home");
			}

			if (Request.Cookies["kullaniciBilgileri"] != null)
			{
				var httpCookie = Request.Cookies["kullaniciBilgileri"];
				vm.KullaniciAdi = httpCookie.Values["username"];
			}
			return View(vm);
		}

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(LoginVM loginVm)
        {

	        UserDAL userDal = new UserDAL();
	        var user = userDal.CheckUser(loginVm);

	        if (user == null)
	        {
		        ViewBag.HataMesaji = "Kullanıcı adı veya şifre hatalı";
		        return View("Index");
	        }

	        Session.Add("loginUser", user);

	        FormsAuthentication.SetAuthCookie(user.Username + user.RoleId, true);

	        HttpCookie cookie = new HttpCookie("kullaniciBilgileri");
	        if (loginVm.BeniHatirla)
	        {
		        cookie.Expires = DateTime.Now.AddDays(1);
		        cookie.Values.Add("username", loginVm.Username);
		        HttpContext.Response.Cookies.Add(cookie);
	        }
	        return RedirectToAction("Index", "Home");
        }
	}
}