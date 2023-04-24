using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemi.Entities.Entities.Bases;

namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class AracOzellik : BaseEntity
	{
		public int AracId { get; set; }
		public int OzellikDetayId { get; set; }
		public Arac Arac { get; set; }
		public OzellikDetay OzellikDetay { get; set; }
	}
}
