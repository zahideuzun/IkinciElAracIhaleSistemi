using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Entities
{
	public class OzellikDetay
	{
		public int OzellikDetayId { get; set; }
		public int OzellikId { get; set; }
		public string OzellikDetayi { get; set; }
		public ICollection<AracOzellik> AracOzellikleri { get; set; }
		public ICollection<FavoriOzellik> FavoriOzellikleri { get; set; }
		public Ozellik Ozellik { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
	}
}
