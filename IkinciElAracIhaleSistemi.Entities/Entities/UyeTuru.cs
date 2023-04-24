using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class UyeTuru
	{
		public int UyeTuruId { get; set; }
		public string UyeTuruAdi { get; set; }
		public ICollection<Uye> Uye { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
	}
}
