using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.DAL.Context;
using IkinciElAracIhaleSistemi.Entities.VM;

namespace IkinciElAracIhaleSistemi.DAL.DAL
{
	public class IletisimDAL
	{
		public List<IletisimBilgiVM> IletisimTurleriniGetir()
		{
			using (AracIhaleContext db = new AracIhaleContext())
				return (from m in db.Iletisimler
					where m.IsActive == true
					select new IletisimBilgiVM()
					{
						Id = m.IletisimId,
						IletisimAdi = m.IletisimAdi

					}).ToList();
		}
	}
}
