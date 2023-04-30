using IkinciElAracIhaleSistemi.Entities.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class BireyselUye : BaseEntity
	{
		public int UyeId { get; set; }
		public string TcKimlikNo { get; set; }
		public int RolId { get; set; }

		public Rol Rol { get; set; }
		public Uye Uye { get; set; }
		
	}
}
