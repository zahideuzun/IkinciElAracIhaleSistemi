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
using IkinciElAracIhaleSistemi.Entities.VM.Enum;

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

						foreach (var t in aracTramer.Children)
						{
							AracTramerDetay aracTramerDetay = aracDb.AracTramerDetaylari.Add(new AracTramerDetay()
							{
								AracTramerId = eklenenTramer.AracTramerId,
							});
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

		public List<AracTramerDetayGoruntulemeVM> TramerDetaylariniGetir(int aracId)
		{
			using (AracIhaleContext db = new AracIhaleContext())
			{

				var aracParcalari = db.AracParcalari.ToList();
				var tramerler = db.Tramerler.ToList();

				var parcaDurumListesi = new List<AracTramerDetayGoruntulemeVM>();
				var aracIdyeGoreTramerId = db.AracTramerleri.SingleOrDefault(a => a.AracId == aracId);
				if (aracIdyeGoreTramerId == null) return parcaDurumListesi;
				{
					var aracTramerId = aracIdyeGoreTramerId.AracTramerId;
					var sorgu = db.AracTramerDetaylari.Where(a => a.AracTramerId == aracTramerId).ToList();

					foreach (var parca in aracParcalari)
					{
						var parcaId = parca.AracParcaId;
						var parcaAdi = parca.ParcaAdi;

						foreach (var tramer in tramerler)
						{
							var tramerId = tramer.TramerId;
							var tramerAdi = tramer.TramerAdi;


							foreach (var aracTramerleri in sorgu)
							{
								if (aracTramerleri.AracParcaId == parcaId && aracTramerleri.TramerId == tramerId)
								{
									parcaDurumListesi.Add(new AracTramerDetayGoruntulemeVM
									{
										ParcaAdi = parcaAdi,
										DurumAdi = tramerAdi,
										Fiyat = aracIdyeGoreTramerId.TramerFiyati
										
									});
								}
							}

						}

					}

					return parcaDurumListesi;
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
