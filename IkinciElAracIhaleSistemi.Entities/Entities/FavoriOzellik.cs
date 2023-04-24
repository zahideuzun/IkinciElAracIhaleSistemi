using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities.Bases;

namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class FavoriOzellik : BaseEntity
	{
		public int OzellikDetayId { get; set; }
		public int FavoriAramaKriterId { get; set; }
		public OzellikDetay OzellikDetay { get; set; }
		public FavoriAramaKriter FavoriAramaKriter { get; set; }
	}
}
