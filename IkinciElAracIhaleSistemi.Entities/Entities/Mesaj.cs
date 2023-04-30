using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class Mesaj
	{
		public int MesajId { get; set; }
		public string MesajBilgisi { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
		public int UyeId { get; set; }


		public Uye Uye { get; set; }
		
	}
}
