using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemi.Entities.Entities.Bases;

namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class AracFiyat : BaseEntity
	{
		public int AracId { get; set; }
		public decimal Fiyat { get; set; }
		public DateTime Tarih { get; set; }
		public Arac Arac { get; set; }
	}
}
