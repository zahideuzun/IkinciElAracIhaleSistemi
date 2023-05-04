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
		public List<AracEklemeDetayVM> AracOzellikleriGetir(int OzellikId)
		{
			using (AracIhaleContext db = new AracIhaleContext())
			{
				var ozellikListesi = (from ozd in db.OzellikDetaylari
								 join oz in db.Ozellikler on ozd.OzellikId equals oz.OzellikId
								 where oz.OzellikId == OzellikId
									  select new AracEklemeDetayVM()
								 {
									 OzellikDetayId = ozd.OzellikDetayId,
									 OzellikDetayAdi = ozd.OzellikDetayi
								 }).ToList();
				return ozellikListesi;
			}
		}
		public List<SelectListItem> AracOzellikleriniListeyeDonustur(int ozellikId)
		{
			var ozellikListesi = new AracOzellikDAL().AracOzellikleriGetir(ozellikId)
				.Select(r => new SelectListItem()
				{
					Value = r.OzellikDetayId.ToString(),
					Text = r.OzellikDetayAdi,
				}).ToList();

			return ozellikListesi;
		}
		
	}
}
