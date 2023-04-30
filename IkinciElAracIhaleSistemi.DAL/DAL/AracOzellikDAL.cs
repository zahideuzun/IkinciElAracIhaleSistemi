using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using IkinciElAracIhaleSistemi.DAL.Context;
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
		public List<SelectListItem> AracOzellikleriniListeyeDonustur(AracOzellikleri ozellik)
		{
			var ozellikListesi = new AracOzellikDAL().AracOzellikleriGetir(ozellik)
				.Select(r => new SelectListItem()
				{
					Value = r.OzellikDetayId.ToString(),
					Text = r.OzellikDetayAdi,
				}).ToList();

			return ozellikListesi;
		}
		//public List<SelectListItem> AracOzellikleriniListeyeDonustur(AracOzellikleri ozellik, int aracId)
		//{
		//	var ozellikListesi = new AracOzellikDAL().AracOzellikleriGetir(ozellik)
		//		.Select(r => new SelectListItem()
		//		{
		//			Value = r.OzellikDetayId.ToString(),
		//			Text = r.OzellikDetayAdi,
		//		}).ToList();

		//	return ozellikListesi;
		//}
	}
}
