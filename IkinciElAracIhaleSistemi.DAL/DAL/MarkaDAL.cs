using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
	}
}
