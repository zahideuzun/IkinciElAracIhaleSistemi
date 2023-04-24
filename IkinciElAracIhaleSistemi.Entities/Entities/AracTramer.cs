using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;

namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class AracTramer
	{
		public int AracTramerId { get; set; }
		public int AracId { get; set; }
		public decimal TramerFiyati { get; set; }
		public Arac Arac { get; set; }
		public virtual ICollection<AracTramerDetay> AracTramerDetaylari { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
	}
}
