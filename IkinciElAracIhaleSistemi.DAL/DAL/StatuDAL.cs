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
	public class StatuDAL
	{
		public List<StatuVM> StatuleriGetir()
		{
			using (var db = new AracIhaleContext())
			{
				return db.Status
					.Where(s => s.IsActive)
					.Select(s => new StatuVM
					{
						StatuId = s.StatuId,
						StatuAdi = s.StatuAdi
					})
					.ToList();
			}
		}
		public List<SelectListItem> StatuListesineDonustur()
		{
			var statuVm = new AracEklemeDetayVM();
			statuVm.Statuler = new StatuDAL().StatuleriGetir()
				.Select(r => new SelectListItem()
				{
					Value = r.StatuId.ToString(),
					Text = r.StatuAdi
				}).ToList();
			return statuVm.Statuler;
		}
	}
}
