using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.DAL.Entities.Bases;

namespace IkinciElAracIhaleSistemi.DAL.Entities
{
	public class AracFiyat : BaseEntity
	{
		public int AracId { get; set; }
		public decimal Fiyat { get; set; }
		public DateTime Tarih { get; set; }
		public Arac Arac { get; set; }
	}
}
