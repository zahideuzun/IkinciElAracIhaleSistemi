using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkinciElAracIhaleSistemi.Entities.VM
{
	public class KullaniciRolVM
	{
		public int KullaniciId { get; set; }
		public string KullaniciAdi { get; set; }
		public string KullaniciIsim { get; set; }
		public string KullaniciSoyisim { get; set; }
		public string KullaniciSifre { get; set; }
		public string KullaniciMail { get; set; }
		public string KullaniciTelefon { get; set; }
		public string RolAdi { get; set; }
		public int RolId { get; set; }
		
	}
}