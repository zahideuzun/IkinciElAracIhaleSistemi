using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class FavoriArama 
	{
		public int FavoriAramaId { get; set; }
		public int FavoriAramaKriterId { get; set; }
		public int UyeId { get; set; }
		public string AramaAdi { get; set; }
		public FavoriAramaKriter FavoriAramaKriter { get; set; }
		public Uye Uye { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
	}
}
