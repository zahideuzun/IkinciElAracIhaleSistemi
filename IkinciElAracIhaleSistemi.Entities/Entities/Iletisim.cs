using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class Iletisim
	{
		public int IletisimId { get; set; }
		public string IletisimAdi { get; set; }
		public ICollection<UyeIletisim> UyeIletisim { get; set; }
		public ICollection<FirmaIletisim> FirmaIletisim { get; set; }
		public ICollection<KullaniciIletisim> KullaniciIletisim { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
	}
}
