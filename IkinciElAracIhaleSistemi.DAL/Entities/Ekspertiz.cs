using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Entities
{
	public class Ekspertiz
	{
		public int EkspertizId { get; set; }
		public string Ad { get; set; }
		public string Adres { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
	}
}
