using IkinciElAracIhaleSistemi.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.VM.Arac;
using System.Web.Mvc;

namespace IkinciElAracIhaleSistemi.DAL.DAL.Metot
{
	//public class ListeDonustur
	//{
	//	public List<SelectListItem> FirmaListesineDonustur()
	//	{
	//		var firmaVm = new AracEklemeDetayVM();
	//		firmaVm.Firmalar = new FirmaDAL().FirmalariGetir()
	//			.Select(r => new SelectListItem()
	//			{
	//				Value = r.FirmaId.ToString(),
	//				Text = r.FirmaAdi
	//			}).ToList();


	//		return firmaVm.Firmalar;

	//	}

	//	public List<SelectListItem> DonanimListesineDonustur()
	//	{
	//		var rolVm = new AracEklemeDetayVM();
	//		rolVm.Donanimlar = new AracOzellikDAL().AracDonanimGetir()
	//			.Select(r => new SelectListItem()
	//			{
	//				Value = r.DonanimId.ToString(),
	//				Text = r.Donanim
	//			}).ToList();
	//		return rolVm.Donanimlar;
	//	}

	//	public List<SelectListItem> VersiyonListesineDonustur()
	//	{
	//		var rolVm = new AracOzellikVM();
	//		rolVm.Versiyonlar = new AracOzellikDAL().AracVersiyonGetir()
	//			.Select(r => new SelectListItem()
	//			{
	//				Value = r.VersiyonId.ToString(),
	//				Text = r.VersiyonTipi
	//			}).ToList();
	//		return rolVm.Versiyonlar;
	//	}

	//	public List<SelectListItem> StatuListesineDonustur()
	//	{
	//		var rolVm = new AracOzellikVM();
	//		rolVm.Statuler = new StatuDAL().StatuleriGetir()
	//			.Select(r => new SelectListItem()
	//			{
	//				Value = r.StatuId.ToString(),
	//				Text = r.StatuAdi
	//			}).ToList();
	//		return rolVm.Statuler;
	//	}

	//	public List<SelectListItem> GovdeTipiListesineDonustur()
	//	{
	//		var rolVm = new AracOzellikVM();
	//		rolVm.GovdeTipleri = new AracOzellikDAL().AracGovdeGetir()
	//			.Select(r => new SelectListItem()
	//			{
	//				Value = r.GovdeTipiId.ToString(),
	//				Text = r.GovdeTipi
	//			}).ToList();
	//		return rolVm.GovdeTipleri;
	//	}

	//	public List<SelectListItem> YakitTipiListesineDonustur()
	//	{
	//		var rolVm = new AracOzellikVM();
	//		rolVm.YakitTipleri = new AracOzellikDAL().AracYakitGetir()
	//			.Select(r => new SelectListItem()
	//			{
	//				Value = r.YakitTipiId.ToString(),
	//				Text = r.YakitTipi
	//			}).ToList();
	//		return rolVm.YakitTipleri;
	//	}

	//	public List<SelectListItem> VitesTipiListesineDonustur()
	//	{
	//		var rolVm = new AracOzellikVM();
	//		rolVm.VitesTipleri = new AracOzellikDAL().AracVitesGetir()
	//			.Select(r => new SelectListItem()
	//			{
	//				Value = r.VitesTipiId.ToString(),
	//				Text = r.VitesTipi
	//			}).ToList();
	//		return rolVm.VitesTipleri;
	//	}

	//	public List<SelectListItem> RenkListesineDonustur()
	//	{
	//		var rolVm = new AracOzellikVM();
	//		rolVm.Renkler = new AracOzellikDAL().AracRenkGetir()
	//			.Select(r => new SelectListItem()
	//			{
	//				Value = r.RenkId.ToString(),
	//				Text = r.Renk
	//			}).ToList();
	//		return rolVm.Renkler;
	//	}

	//	public List<SelectListItem> MarkaListesineDonustur()
	//	{
	//		var rolVm = new MarkaVM();
	//		rolVm.Markalar = new MarkaDAL().MarkalariGetir()
	//			.Select(r => new SelectListItem()
	//			{
	//				Value = r.MarkaId.ToString(),
	//				Text = r.MarkaAdi
	//			}).ToList();
	//		return rolVm.Markalar;
	//	}

	//	public List<SelectListItem> ModelListesineDonustur()
	//	{
	//		var rolVm = new ModelVM();
	//		rolVm.Modeller = new ModelDAL().ModelleriGetir()
	//			.Select(r => new SelectListItem()
	//			{
	//				Value = r.ModelId.ToString(),
	//				Text = r.ModelAdi
	//			}).ToList();
	//		return rolVm.Modeller;
	//	}
	//}
}