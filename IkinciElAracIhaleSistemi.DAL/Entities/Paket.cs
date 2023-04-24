using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Entities
{
	public class Paket
	{
		public int PaketId { get; set; }
		public string Ad { get; set; }
		public int AracLimiti { get; set; }
		public ICollection<Firma> Firma { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
	}
}
