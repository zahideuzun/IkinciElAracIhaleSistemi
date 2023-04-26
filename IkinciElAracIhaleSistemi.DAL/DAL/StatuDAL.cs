using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.DAL.Context;
using IkinciElAracIhaleSistemi.Entities.VM;

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
	}
}
