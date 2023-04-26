using IkinciElAracIhaleSistemi.DAL.Context;
using IkinciElAracIhaleSistemi.Entities.VM.Arac;
using System.Collections.Generic;
using System.Linq;

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
	}
}
