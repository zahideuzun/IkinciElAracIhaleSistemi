using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using IkinciElAracIhaleSistemi.DAL.Context;
using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemi.Entities.VM;
using IkinciElAracIhaleSistemi.Entities.VM.Arac;

namespace IkinciElAracIhaleSistemi.DAL.DAL
{
	public class FirmaDAL
	{
		public List<FirmaVM> FirmalariGetir()
		{
			using (AracIhaleContext db = new AracIhaleContext())
			{
				return (from m in db.Firmalar
					where m.IsActive == true
					select new FirmaVM()
					{
						FirmaId = m.Id,
						FirmaAdi = m.Unvan

					}).ToList();

			}

		}
		public List<SelectListItem> FirmaListesineDonustur()
		{
			var firmaVm = new AracEklemeDetayVM();
			firmaVm.Firmalar = new FirmaDAL().FirmalariGetir()
				.Select(r => new SelectListItem()
				{
					Value = r.FirmaId.ToString(),
					Text = r.FirmaAdi
				}).ToList();
			return firmaVm.Firmalar;
		}

	}
}
