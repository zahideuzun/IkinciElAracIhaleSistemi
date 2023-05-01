using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using IkinciElAracIhaleSistemi.DAL.Context;
using IkinciElAracIhaleSistemi.Entities.VM.Arac;

namespace IkinciElAracIhaleSistemi.DAL.DAL
{
	public class AracParcaDAL
	{
		public List<AracParcaVM> AracParcalariGetir()
		{
			using (AracIhaleContext db = new AracIhaleContext())
			{
				return (from m in db.AracParcalari
					where m.IsActive == true
					select new AracParcaVM()
					{
						AracParcaId = m.AracParcaId,
						AracParcaAdi = m.ParcaAdi

					}).ToList();
			}

		}
		//public List<SelectListItem> AracParcaListesineDonustur()
		//{
		//	var parcaVm = new AracParcaVM();
		//	parcaVm.Parcalar = new MarkaDAL().MarkalariGetir()
		//		.Select(r => new SelectListItem()
		//		{
		//			Value = r.MarkaId.ToString(),
		//			Text = r.MarkaAdi
		//		}).ToList();
		//	return parcaVm.Markalar;
		//}
	}
}
