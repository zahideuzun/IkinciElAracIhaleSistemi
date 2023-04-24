using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace IkinciElAracIhaleSistemi.UI.Models.VM
{
	public class LoginVM
	{
		[Display(Name = "Kullanıcı Id")]
		public int KullaniciId { get; set; }
		[Display(Name = "Kullanıcı Adı")]

		[StringLength(24)]
		public string KullaniciAdi { get; set; }
		[Display(Name = "Şifre")]
		[Required]
		public string Sifre { get; set; }
		[Display(Name = "Mail Adresi")]

		public string Mail { get; set; }

		public bool BeniHatirla { get; set; }
		public bool BeniUnut { get; set; }
	}
}