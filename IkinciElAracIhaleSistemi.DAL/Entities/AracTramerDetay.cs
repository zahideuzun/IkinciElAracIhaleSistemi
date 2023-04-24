using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Entities
{
	public class AracTramerDetay
	{
		public int AracTramerDetayId { get; set; }
		public int TramerId { get; set; }
		public int AracParcaId { get; set; }
		public int AracTramerId { get; set; }
		public Tramer Tramer { get; set; }
		public AracParca AracParca { get; set; }
		public AracTramer AracTramer { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
	}
}
