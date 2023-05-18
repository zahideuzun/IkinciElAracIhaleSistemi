using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities.Bases;

namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class Sayfa :IEntity
	{
		public int SayfaId { get; set; }
		public string SayfaAdi { get; set; }
		public string SayfaLink { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
		public ICollection<RolYetki> SayfaRolYetkileri { get; internal set; }
	}
}
