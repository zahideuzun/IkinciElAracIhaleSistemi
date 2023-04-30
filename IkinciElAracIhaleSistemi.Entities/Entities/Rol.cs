using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class Rol
	{
		public int RolId { get; set; }
		public string RolAdi { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
		
		public ICollection<BireyselUye> BireyselUyeler { get; set; }
		public ICollection<Kullanici> Kullanicilar { get; set; }
		public ICollection<KurumsalUye> KurumsalUyeler { get; set; }
		
		public ICollection<RolYetki> RolYetkileri { get; set; }
	}
}
