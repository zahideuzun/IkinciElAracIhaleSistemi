using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.App.Results.Bases;
using IkinciElAracIhaleSistemi.App.Results;
using IkinciElAracIhaleSistemi.DAL.Context;
using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemi.Entities.VM;
using IkinciElAracIhaleSistemi.Entities.VM.Arac;
using System.Transactions;

namespace IkinciElAracIhaleSistemi.DAL.DAL
{
	public class AracTramerDetayDAL
	{

		public Result TramerEkle(AracTramerDetayEklemeVM aracTramer)
		{
			using (TransactionScope scope = new TransactionScope())
			{
				try
				{
					using (AracIhaleContext aracDb = new AracIhaleContext())
					{
						AracTramer eklenenTramer = aracDb.AracTramerleri.Add(new AracTramer()
						{
							AracId = aracTramer.AracId,
							TramerFiyati = aracTramer.Fiyat
							//todo created by
						});

						AracTramerDetay aracTramerDetay = aracDb.AracTramerDetaylari.Add(new AracTramerDetay()
						{
							AracTramerId = eklenenTramer.AracTramerId,
						});

						foreach (var t in aracTramer.Children)
						{
							aracTramerDetay.AracParcaId = t.ParcaId;
							aracTramerDetay.TramerId = t.TramerId;
						}
						

						aracDb.SaveChanges();
					}

					scope.Complete();
					return new SuccessResult("Tramer kaydedildi");

				}
				catch
				{
					scope.Complete();
					return new ErrorResult("Tramer kaydedilemedi!");
				}
			}
		}












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
		public List<AracParcaVM> AracParcalariGetir()
		{
			using (AracIhaleContext db = new AracIhaleContext())
			{
				return (from m in db.AracParcalari
					where m.IsActive == true
					select new AracParcaVM()
					{
						AracParcaId = m.AracParcaId,
						AracParcaAdi = m.ParcaAdi

					}).ToList();
			}
		}
	}
}
