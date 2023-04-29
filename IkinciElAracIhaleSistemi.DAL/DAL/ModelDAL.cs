using IkinciElAracIhaleSistemi.DAL.Context;
using IkinciElAracIhaleSistemi.Entities.VM.Arac;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IkinciElAracIhaleSistemi.DAL.DAL
{
	public class ModelDAL
	{
		public List<ModelVM> ModelleriGetir()
		{
			using (AracIhaleContext db = new AracIhaleContext())
			{
				return (from m in db.Modeller
					where m.IsActive == true
					select new ModelVM()
					{
						ModelId = m.ModelId,
						ModelAdi = m.ModelAdi

					}).ToList();
			}
			
		}
		public List<ModelVM> MarkayaGoreModelleriGetir(int id)
		{
			using (AracIhaleContext db = new AracIhaleContext())
			{
				return (from m in db.Modeller
					where m.IsActive == true && m.MarkaId == id
					select new ModelVM()
					{
						ModelId = m.ModelId,
						ModelAdi = m.ModelAdi

					}).ToList();
			}

		}
		public List<SelectListItem> ModelListesineDonustur()
		{
			var modelVm = new ModelVM();
			modelVm.Modeller = new ModelDAL().ModelleriGetir()
				.Select(r => new SelectListItem()
				{
					Value = r.ModelId.ToString(),
					Text = r.ModelAdi
				}).ToList();
			return modelVm.Modeller;
		}
	}
}
