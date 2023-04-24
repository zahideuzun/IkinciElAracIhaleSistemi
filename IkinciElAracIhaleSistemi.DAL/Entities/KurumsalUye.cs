using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.DAL.Entities.Bases;

namespace IkinciElAracIhaleSistemi.DAL.Entities
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
