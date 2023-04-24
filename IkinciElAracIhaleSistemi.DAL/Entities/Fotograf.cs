using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Entities
{
	public class Fotograf
	{
		public int FotografId { get; set; }
		public string FotografYolu { get; set; }
		public int AracId { get; set; }
		public Arac Arac { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
	}
}
