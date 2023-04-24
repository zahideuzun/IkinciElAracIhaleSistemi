using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Entities
{
	public class SehirIlce
	{
		public int SehirIlceId { get; set; }
		public int SehirId { get; set; }
		public int IlceId { get; set; }
		public Sehir Sehir { get; set; }
		public Ilce Ilce { get; set; }
		public ICollection<Firma> Firmalar { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
	}
}
