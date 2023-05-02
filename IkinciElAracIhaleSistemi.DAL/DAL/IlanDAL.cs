using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using IkinciElAracIhaleSistemi.App.Results;
using IkinciElAracIhaleSistemi.App.Results.Bases;
using IkinciElAracIhaleSistemi.DAL.Context;
using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemi.Entities.VM.Arac;

namespace IkinciElAracIhaleSistemi.DAL.DAL
{
	public class IlanDAL
	{
		public Result IlanEkle(AracIlanVM ilan)
		{
			try
			{
				using (AracIhaleContext aracDb = new AracIhaleContext())
				{
					Ilan eklenenAracIlani = aracDb.Ilanlar.Add(new Ilan()
					{
						AracId = ilan.AracId,
						Baslik = ilan.Baslik,
						Aciklama = ilan.Aciklama
					});
				}
				return new SuccessResult("Araç kaydedildi");
			}
			catch
			{
				return new ErrorResult("Araç kaydedilemedi!");
			}
			
		}
	}
}
