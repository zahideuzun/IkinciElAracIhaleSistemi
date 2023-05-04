using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.Entities.VM.Arac
{
	public class AracIlanVM
	{
		public int AracId { get; set; }
		public int IlanId { get; set; }
		public string AracMarka { get; set; }
		public string AracModel { get; set; }
		public string Baslik { get; set; }
		public string Aciklama { get; set; }
		public string Tarih { get; set; }
	}
}
