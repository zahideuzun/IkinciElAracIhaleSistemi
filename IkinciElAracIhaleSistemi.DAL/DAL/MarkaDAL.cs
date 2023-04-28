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
	public class MarkaDAL
	{
		public List<MarkaVM> MarkalariGetir()
		{
			using (AracIhaleContext db = new AracIhaleContext())
			{
				return (from m in db.Markalar
					where m.IsActive == true
					select new MarkaVM()
					{
						MarkaId = m.MarkaId,
						MarkaAdi = m.MarkaAdi

					}).ToList();
			}
			
		}
		public List<SelectListItem> MarkaListesineDonustur()
		{
			var markaVm = new MarkaVM();
			markaVm.Markalar = new MarkaDAL().MarkalariGetir()
				.Select(r => new SelectListItem()
				{
					Value = r.MarkaId.ToString(),
					Text = r.MarkaAdi
				}).ToList();
			return markaVm.Markalar;
		}
	}
}
