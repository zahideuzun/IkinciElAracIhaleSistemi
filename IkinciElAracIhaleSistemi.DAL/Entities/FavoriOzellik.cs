using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.DAL.Entities.Bases;

namespace IkinciElAracIhaleSistemi.DAL.Entities
{
	public class FavoriOzellik : BaseEntity
	{
		public int OzellikDetayId { get; set; }
		public int FavoriAramaKriterId { get; set; }
		public OzellikDetay OzellikDetay { get; set; }
		public FavoriAramaKriter FavoriAramaKriter { get; set; }
	}
}
