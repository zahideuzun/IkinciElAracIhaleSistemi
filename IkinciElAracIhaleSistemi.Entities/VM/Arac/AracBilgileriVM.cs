using IkinciElAracIhaleSistemi.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IkinciElAracIhaleSistemi.Entities.VM.Arac
{
	public class AracBilgileriVM
	{
		public int AracId { get; set; }
		public string Plaka { get; set; }
		public int Km { get; set; }
		public string MarkaAdi { get; set; }
		public string ModelAdi { get; set; }
		public string BireyselMi { get; set; }
		public string Statu { get; set; }
		public string KaydedenKullanici { get; set; }
		public DateTime KaydedilmeZamani { get; set; }
		public MarkaVM Marka { get; set; }
		public ModelVM Model { get; set; }
		public OzellikDetay OzellikDetay { get; set; }
		public Ozellik Ozellik { get; set; }
		public Statu Status { get; set; }
		public KullaniciRolVM Kullanici { get; set; }
		public List<SelectListItem> Markalar { get; set; }
	}
}
