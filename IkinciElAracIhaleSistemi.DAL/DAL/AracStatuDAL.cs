using IkinciElAracIhaleSistemi.DAL.Context;
using IkinciElAracIhaleSistemi.Entities.VM;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.VM.Arac;

namespace IkinciElAracIhaleSistemi.DAL.DAL
{
	public class AracStatuDAL
	{
		public List<AracStatuVM> StatuleriGetir(int id)
		{
			using (var db = new AracIhaleContext())
			{
				var query = from s in db.Status
					join a in db.AracStatu on s.StatuId equals a.StatuId
					where a.AracId == id
					select new AracStatuVM
					{
						StatuId = s.StatuId,
						StatuAdi = s.StatuAdi,
						AracId = a.AracId,
						Tarih = a.Tarih,
						AktifMi = a.IsActive ? "Evet":"Hayır",
					};

				return query.ToList();

			}
		}
	}
}
