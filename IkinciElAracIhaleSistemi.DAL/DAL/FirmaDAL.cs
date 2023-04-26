using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.DAL.Context;
using IkinciElAracIhaleSistemi.Entities.VM;

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
	}
}
