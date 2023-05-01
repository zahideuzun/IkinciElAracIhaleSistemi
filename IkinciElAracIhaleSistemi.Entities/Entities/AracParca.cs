using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class AracParca
	{
		public int AracParcaId { get; set; }
		public string ParcaAdi { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;

		public override string ToString()
		{
			return ParcaAdi;
		}
	}
}
