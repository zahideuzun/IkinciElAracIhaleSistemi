using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Entities
{
	public class Sayfa
	{
		public int SayfaId { get; set; }
		public string SayfaAdi { get; set; }
		public string SayfaLink { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
		public ICollection<RolYetki> SayfaRolYetkileri { get; internal set; }
	}
}
