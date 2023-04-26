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
	public class ListeDonustur
	{
		[NonAction]
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
