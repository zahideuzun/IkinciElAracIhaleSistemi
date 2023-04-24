using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.DAL.Entities.Bases;

namespace IkinciElAracIhaleSistemi.DAL.Entities
{
	public class AracIhale : BaseEntity
	{
		public int AracId { get; set; }
		public int IhaleId { get; set; }
		public decimal IhaleBaslangicFiyati { get; set; }
		public decimal MinimumAlimFiyati { get; set; }
		public Arac Arac { get; set; }
		public Ihale Ihale { get; set; }
		public ICollection<AracTeklif> AracTeklifler { get; internal set; }
	}
}
