using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Entities
{
	public class Rol
	{
		public int RolId { get; set; }
		public string RolAdi { get; set; }
		public ICollection<Uye> Uyeler { get; set; }
		public ICollection<Kullanici> Kullanicilar { get; set; }
		public ICollection<KurumsalUye> KurumsalUyeler { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
		public ICollection<RolYetki> RolYetkileri { get; internal set; }
	}
}
