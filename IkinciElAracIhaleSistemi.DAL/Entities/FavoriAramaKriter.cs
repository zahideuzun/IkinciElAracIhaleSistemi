using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Entities
{
	public class FavoriAramaKriter
	{
		public int FavoriAramaKriterId { get; set; }	
		public int MarkaId { get; set; }
		public int ModelId { get; set; }
		public int BaslangicYili { get; set; }
		public int BitisYili { get; set; }
		public decimal BaslangicFiyati { get; set; }
		public decimal BitisFiyati { get; set; }
		public int BaslangicKm { get; set; }
		public int BitisKm { get; set; }
		public Marka Marka { get; set; }
		public Model Model { get; set; }
		public ICollection<FavoriArama> FavoriAramalar { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;

	}
}
