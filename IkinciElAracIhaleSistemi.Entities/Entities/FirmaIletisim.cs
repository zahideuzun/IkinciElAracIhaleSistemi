using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities.Bases;

namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class FirmaIletisim : BaseEntity
	{
		public int IletisimId { get; set; }
		public int FirmaId { get; set; }
		public string IletisimBilgi { get; set; }
		public Iletisim Iletisim { get; set; }
		public Firma Firma { get; set; }
	}
}
