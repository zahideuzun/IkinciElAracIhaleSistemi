using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.DAL.Entities.Bases;

namespace IkinciElAracIhaleSistemi.DAL.Entities
{
	public class Ihale : BaseEntity
	{
		public string IhaleAdi { get; set; }
		public DateTime IhaleBaslangicTarihi { get; set; }
		public DateTime IhaleBitisTarihi { get; set; }
		public TimeSpan BaslangicSaat { get; set; }
		public TimeSpan BitisSaat { get; set; }
		public int IhaleTuruId { get; set; }
		public IhaleTuru IhaleTuru { get; set; }
		public int KullaniciId { get; set; }
		public Kullanici Kullanici { get; set; }
		public ICollection<AracIhale> AracIhale { get; set; }
		public ICollection<IhaleStatu> IhaleStatu { get; set; }
	}
}
