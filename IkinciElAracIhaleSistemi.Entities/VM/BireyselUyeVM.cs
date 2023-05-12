using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.Entities.VM
{
	public class BireyselUyeVM
	{
		public int UyeId { get; set; }
		public string Isim { get; set; }
		public string Soyisim { get; set; }
		public string Mail { get; set; }
		public string Telefon { get; set; }
		public string Sifre { get; set; }
		public string TcKimlik { get; set; }
		public string OnayliMi { get; set; }
        public int RolId { get; set; }

	}
}
