using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities.Bases;

namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class Ucret : BaseEntity
	{
		public int UcretTipiId { get; set; }
		public DateTime BaslangicTarihi { get; set; }
		public DateTime BitisTarihi { get; set; }
		public decimal UcretTL { get; set; }
		public UcretTipi UcretTipi { get; set; }
	}
}
