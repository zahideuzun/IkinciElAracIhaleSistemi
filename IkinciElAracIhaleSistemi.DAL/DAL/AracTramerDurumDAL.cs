using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.DAL.Context;
using IkinciElAracIhaleSistemi.Entities.VM.Arac;

namespace IkinciElAracIhaleSistemi.DAL.DAL
{
	public class AracTramerDurumDAL
	{
		public List<AracTramerVM> AracTramerDurumlariniGetir()
		{
			using (AracIhaleContext db = new AracIhaleContext())
			{
				return (from m in db.Tramerler
					where m.IsActive == true
					select new AracTramerVM()
					{
						TramerDurumId = m.TramerId,
						TramerDurumAdi = m.TramerAdi

					}).ToList();
			}

		}
	}
}
