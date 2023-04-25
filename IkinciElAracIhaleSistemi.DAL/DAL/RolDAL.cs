using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.DAL.Context;
using IkinciElAracIhaleSistemi.Entities.VM;

namespace IkinciElAracIhaleSistemi.DAL.DAL
{
	public class RolDAL
	{
		public List<RolVM> RolleriGetir()
		{
			using (AracIhaleContext db = new AracIhaleContext())
			return (from m in db.Roller
				where m.IsActive == true
				select new RolVM()
				{
					Id = m.RolId,
					RolAdi = m.RolAdi

				}).ToList();
		}
	}
}
