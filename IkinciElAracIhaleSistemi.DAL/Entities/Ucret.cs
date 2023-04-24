using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.DAL.Entities.Bases;

namespace IkinciElAracIhaleSistemi.DAL.Entities
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
