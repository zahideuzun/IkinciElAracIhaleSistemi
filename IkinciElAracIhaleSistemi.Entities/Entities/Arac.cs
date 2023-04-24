using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities.Bases;

namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class Arac : BaseEntity
	{
		public int Yil { get; set; }
		public string Plaka { get; set; }
		public int KullaniciId { get; set; }
		public int MarkaId { get; set; }
		public int ModelId { get; set; }
		public decimal Km { get; set; }
		public bool BireyselMi { get; set; }
		public Model Model { get; set; }
		public Marka Marka { get; set; }

		[ForeignKey("KullaniciId")]
		public Kullanici Kullanici { get; set; }

		public ICollection<AracFiyat> AracFiyat { get; set; }
		public ICollection<AracOzellik> AracOzellik { get; set; }
		public ICollection<AracStatu> AracStatu { get; set; }
		public ICollection<AracTramer> AracTramer { get; set; }
		public ICollection<Fotograf> Fotograf { get; set; }
		public ICollection<AracIhale> AracIhale { get; set; }
		public ICollection<Ilan> Ilan { get; set; }
	}
}
