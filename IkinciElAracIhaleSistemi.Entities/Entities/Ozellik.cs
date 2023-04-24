using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class Ozellik
	{
		public int OzellikId { get; set; }	
		public string OzellikAdi { get; set; }
		public ICollection<OzellikDetay> OzellikDetay { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
	}
}
