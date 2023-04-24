using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.DAL.Entities.Bases;

namespace IkinciElAracIhaleSistemi.DAL.Entities
{
	public class AracTeklif : BaseEntity
	{
		public int AracIhaleId { get; set; }
		public int UyeId { get; set; }
		public decimal TeklifEdilenFiyat { get; set; }
		public DateTime TeklifTarihi { get; set; }
		public bool OnaylandiMi { get; set; }
		public AracIhale AracIhale { get; set; }

		[ForeignKey("UyeId")]
		public Uye Uye { get; set; }
	}
}
