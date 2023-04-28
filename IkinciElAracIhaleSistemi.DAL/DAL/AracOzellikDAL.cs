using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using IkinciElAracIhaleSistemi.DAL.Context;
using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemi.Entities.VM.Arac;
using IkinciElAracIhaleSistemi.Entities.VM.Enum;

namespace IkinciElAracIhaleSistemi.DAL.DAL
{
	public class AracOzellikDAL
	{
		public List<AracEklemeDetayVM> AracOzellikleriGetir(AracOzellikleri ozellikAdi)
		{
			using (AracIhaleContext db = new AracIhaleContext())
			{
				var ozellikListesi = (from ozd in db.OzellikDetaylari
								 join oz in db.Ozellikler on ozd.OzellikId equals oz.OzellikId
								 where oz.OzellikAdi == ozellikAdi.ToString()
								 select new AracEklemeDetayVM()
								 {
									 OzellikDetayId = ozd.OzellikDetayId,
									 OzellikDetayAdi = ozd.OzellikDetayi
								 }).ToList();
				return ozellikListesi;
			}
		}
		public List<SelectListItem> AracTuruListesineDonustur()
		{
			var aracVm = new AracEklemeDetayVM();
			aracVm.AracTurleri = new AracOzellikDAL().AracOzellikleriGetir(AracOzellikleri.Tur)
				.Select(r => new SelectListItem()
				{
					Value = r.OzellikDetayId.ToString(),
					Text = r.OzellikDetayAdi,
				}).ToList();
			return aracVm.AracTurleri;
		}
		public List<SelectListItem> VitesTipiListesineDonustur()
		{
			var aracVm = new AracEklemeDetayVM();
			aracVm.VitesTipleri = new AracOzellikDAL().AracOzellikleriGetir(AracOzellikleri.VitesTipi)
				.Select(r => new SelectListItem()
				{
					Value = r.OzellikDetayId.ToString(),
					Text = r.OzellikDetayAdi,
				}).ToList();
			return aracVm.VitesTipleri;
		}
		public List<SelectListItem> GovdeTipiListesineDonustur()
		{
			var aracVm = new AracEklemeDetayVM();
			aracVm.GovdeTipleri = new AracOzellikDAL().AracOzellikleriGetir(AracOzellikleri.GovdeTipi)
				.Select(r => new SelectListItem()
				{
					Value = r.OzellikDetayId.ToString(),
					Text = r.OzellikDetayAdi,
				}).ToList();
			return aracVm.GovdeTipleri;
		}
		public List<SelectListItem> YakitTipiListesineDonustur()
		{
			var aracVm = new AracEklemeDetayVM();
			aracVm.YakitTipleri = new AracOzellikDAL().AracOzellikleriGetir(AracOzellikleri.YakitTipi)
				.Select(r => new SelectListItem()
				{
					Value = r.OzellikDetayId.ToString(),
					Text = r.OzellikDetayAdi,
				}).ToList();
			return aracVm.YakitTipleri;
		}
		public List<SelectListItem> DonanimTipiListesineDonustur()
		{
			var aracVm = new AracEklemeDetayVM();
			aracVm.Donanimlar = new AracOzellikDAL().AracOzellikleriGetir(AracOzellikleri.OpsiyonelDonanim)
				.Select(r => new SelectListItem()
				{
					Value = r.OzellikDetayId.ToString(),
					Text = r.OzellikDetayAdi,
				}).ToList();
			return aracVm.Donanimlar;
		}
		public List<SelectListItem> RenkListesineDonustur()
		{
			var aracVm = new AracEklemeDetayVM();
			aracVm.Renkler = new AracOzellikDAL().AracOzellikleriGetir(AracOzellikleri.Renk)
				.Select(r => new SelectListItem()
				{
					Value = r.OzellikDetayId.ToString(),
					Text = r.OzellikDetayAdi,
				}).ToList();
			return aracVm.Renkler;
		}
		public List<SelectListItem> VersiyonListesineDonustur()
		{
			var aracVm = new AracEklemeDetayVM();
			aracVm.Versiyonlar = new AracOzellikDAL().AracOzellikleriGetir(AracOzellikleri.Versiyon)
				.Select(r => new SelectListItem()
				{
					Value = r.OzellikDetayId.ToString(),
					Text = r.OzellikDetayAdi,
				}).ToList();
			return aracVm.Versiyonlar;
		}
	}
}
