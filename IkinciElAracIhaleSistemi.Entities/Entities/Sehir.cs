using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class Sehir
	{
		public int SehirId { get; set; }
		public string SehirAdi { get; set; }
		public ICollection<SehirIlce> SehirIlceleri { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
	}
}
