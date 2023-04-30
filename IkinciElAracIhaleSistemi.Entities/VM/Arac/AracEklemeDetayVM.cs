using IkinciElAracIhaleSistemi.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IkinciElAracIhaleSistemi.Entities.VM.Arac
{
	public class AracEklemeDetayVM
	{
		public int AracId { get; set; }
		public int OzellikDetayId { get; set; }
		public string OzellikDetayAdi { get; set; }
		public int GovdeTipiId { get; set; }
		public int VersiyonTipiId { get; set; }
		public int RenkId { get; set; }
		public int MarkaId { get; set; }
		public int ModelId { get; set; }
		public int StatuId { get; set; }
		public int VitesTipiId { get; set; }
		public int YakitTipiId { get; set; }
		public int BireyselVeyaFirmaId { get; set; }
		public string Plaka { get; set; }
		public decimal Fiyat { get; set; }
		public decimal Km { get; set; }
		public int DonanimId { get; set; }
		public int Yil { get; set; }
		public int AracTuruId { get; set; }
		public int KaydedenKullaniciId { get; set; } = 1;
		public string Aciklama { get; set; }
		public string Fotograf { get; set; }
		public int ModifiedBy { get; set; } = 1;
		public int CreatedBy { get; set; } = 1;
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime ModifiedDate { get; set; } = DateTime.Now;

		
		public Marka Marka { get; set; }
		public Model Model { get; set; }
		
		public List<SelectListItem> Statuler { get; set; }
		
		public List<SelectListItem> Firmalar { get; set; }
		
		public Firma Firma { get; set; }
		
		public AracFiyat AracFiyat { get; set; }
		
	}
}
