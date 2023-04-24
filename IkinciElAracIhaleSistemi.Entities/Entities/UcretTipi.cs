using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class UcretTipi
	{
		public int UcretTipiId { get; set; }
		public string UcretTipiAdi { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
		public ICollection<Ucret> Ucretler { get; set; }
	}
}
