using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities.Bases;

namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class KurumsalUye : BaseEntity
	{
		public int UyeId { get; set; }
		public int FirmaId { get; set; }
		public bool OnaylandiMi { get; set; }
		public int RolId { get; set; }
		public Rol Rol { get; set; }
		public Uye Uye { get; set; }
		public Firma Firma { get; set; }
	}
}
