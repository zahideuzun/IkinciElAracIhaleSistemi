using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities.Bases;

namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class Uye : BaseEntity
	{
		public int UyeTuruId { get; set; }
		public string Isim { get; set; }
		public string Soyisim { get; set; }
		public string Email { get; set; }
		public string Telefon { get; set; }
		public string Sifre { get; set; }
		

		public ICollection<UyeIletisim> UyeIletisim { get; set; }
		public ICollection<AracTeklif> AracTeklif { get; set; }
		public ICollection<FavoriArama> FavoriArama { get; set; }
		public ICollection<FavoriIlan> FavoriIlan { get; set; }
		public UyeTuru UyeTuru { get; set; }
		public ICollection<Mesaj> Mesajlar { get; set; }
		public ICollection<Arac> Araclar { get; set; }
	}
}
