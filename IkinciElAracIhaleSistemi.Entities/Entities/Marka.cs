using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class Marka
	{
		public int MarkaId { get; set; }
		public string MarkaAdi { get; set; }
		public ICollection<Arac> Arac { get; set; }
		public ICollection<FavoriAramaKriter> FavoriAramaKriter { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
	}
}
