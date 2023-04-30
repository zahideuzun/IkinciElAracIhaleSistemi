using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities.Bases;

namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class Firma : BaseEntity
	{
		public string Unvan { get; set; }
		public int FirmaTuruId { get; set; }
		public int PaketId { get; set; }
		public int SehirIlceId { get; set; }
		
		
		public FirmaTuru FirmaTuru { get; set; }
		public Paket Paket { get; set; }
		public SehirIlce SehirIlce { get; set; }
		public ICollection<FirmaIletisim> FirmaIletisimler { get; set; }
		public ICollection<Stok> Stoklar { get; set; }
		public ICollection<KurumsalUye> KurumsalUyeler { get; set; }
	}
}
