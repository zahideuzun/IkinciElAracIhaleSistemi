﻿using IkinciElAracIhaleSistemi.Entities.Entities;
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
		public int Yil { get; set; }
		public int Id { get; set; }
		public int GovdeTipiId { get; set; }
		public int YakitTipiId { get; set; }
		public int RenkId { get; set; }
		public int VersiyonId { get; set; }
		public string GovdeTipi { get; set; }
		public int DonanimId { get; set; }
		public OzellikDetay OzellikDetay { get; set; }
		public List<SelectListItem> GovdeTipleri { get; set; }
		public List<SelectListItem> YakitTipleri { get; set; }
		public List<SelectListItem> VitesTipleri { get; set; }
		public string YakitTipi { get; set; }
		public string VitesTipi { get; set; }
		public string VersiyonTipi { get; set; }
		public string Renk { get; set; }
		public List<SelectListItem> Renkler { get; set; }
		public List<SelectListItem> Markalar { get; set; }
		public List<SelectListItem> Modeller { get; set; }
		public Marka Marka { get; set; }
		public Model Model { get; set; }
		public int MarkaId { get; set; }
		public int ModelId { get; set; }
		public List<SelectListItem> Statuler { get; set; }
		public int StatuId { get; set; }
		public Statu Statu { get; set; }
		public List<SelectListItem> Versiyonlar { get; set; }
		public string Donanim { get; set; }
		public List<SelectListItem> Donanimlar { get; set; }
		public List<SelectListItem> Firmalar { get; set; }
		public int FirmaId { get; set; }
		public Firma Firma { get; set; }
		public decimal Fiyat { get; set; }
		public decimal Km { get; set; }
		public AracFiyat AracFiyat { get; set; }
		public int VitesTipiId { get; set; }
	}
}