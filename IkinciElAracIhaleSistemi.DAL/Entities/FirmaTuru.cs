using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Entities
{
	public class FirmaTuru
	{
		public int FirmaTuruId { get; set; }
		public string FirmaTuruAdi { get; set; }
		public ICollection<Firma> Firmalar { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
	}
}
