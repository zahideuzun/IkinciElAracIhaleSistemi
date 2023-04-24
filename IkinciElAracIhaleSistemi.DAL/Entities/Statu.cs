using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Entities
{
	public class Statu
	{
		public int StatuId { get; set; }
		public string StatuAdi { get; set; }
		public ICollection<AracStatu> AracStatuList { get; set; }
		public ICollection<IhaleStatu> IhaleStatuList { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
	}
}
