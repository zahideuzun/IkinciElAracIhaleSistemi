using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Entities
{
	public class IhaleTuru
	{
		public int IhaleTuruId { get; set; }
		public string IhaleTuruAdi { get; set; }
		public ICollection<Ihale> Ihale { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
	}
}
