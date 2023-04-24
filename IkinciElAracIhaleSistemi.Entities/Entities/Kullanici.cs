using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class Kullanici
	{
		public int KullaniciId { get; set; }
		public string Isim { get; set; }
		public string Soyisim { get; set; }
		public string KullaniciAdi { get; set; }
		public string Sifre { get; set; }
		public string Telefon { get; set; }
		public string Mail { get; set; }
		public int CreatedBy { get; set; } = 1;
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public int ModifiedBy { get; set; }
		public DateTime ModifiedDate { get; set; } = DateTime.Now;
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
		public int RolId { get; set; }
		public Rol Rol { get; set; }

		public ICollection<Arac> Araclar { get; set; }
		public ICollection<KullaniciIletisim> KullaniciIletisim { get; set; }
		public ICollection<Rol> Roller { get; set; }
		public ICollection<Ihale> Ihaleler { get; set; }
	}
}
