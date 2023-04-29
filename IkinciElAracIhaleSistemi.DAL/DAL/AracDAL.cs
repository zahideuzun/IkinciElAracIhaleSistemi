using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using IkinciElAracIhaleSistemi.App.Results.Bases;
using IkinciElAracIhaleSistemi.App.Results;
using IkinciElAracIhaleSistemi.DAL.Context;
using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemi.Entities.VM;
using IkinciElAracIhaleSistemi.Entities.VM.Arac;
using IkinciElAracIhaleSistemi.Entities.VM.Enum;

namespace IkinciElAracIhaleSistemi.DAL.DAL
{
	public class AracDAL
	{

		public List<AracBilgileriVM> AraclariGetir()
		{
			using (AracIhaleContext db = new AracIhaleContext())
			{
				var liste = (from k in db.Araclar
							 join mr in db.Markalar on k.MarkaId equals mr.MarkaId
							 join md in db.Modeller on k.ModelId equals md.ModelId
							 join ast in db.AracStatu on k.Id equals ast.AracId
							 join st in db.Status on ast.StatuId equals st.StatuId
							 select new AracBilgileriVM()
							 {
								 AracId = k.Id,
								 Plaka = k.Plaka,
								 MarkaAdi = mr.MarkaAdi,
								 ModelAdi = md.ModelAdi,
								 BireyselMi = k.BireyselMi ? "Bireysel" : "Kurumsal",
								 Statu = st.StatuAdi,
								 KaydedenKullanici = k.Kullanici.Isim,
								 KaydedilmeZamani = (DateTime)k.CreatedDate

							 }).ToList();
				return liste;
			}

		}

		public Result AracEkle(AracEklemeDetayVM arac)
		{
			using (TransactionScope scope = new TransactionScope())
			{
				try
				{
					using (AracIhaleContext aracDb = new AracIhaleContext())
					{
						Arac eklenenArac = aracDb.Araclar.Add(new Arac()
						{
							Yil = arac.Yil,
							Plaka = arac.Plaka,
							KullaniciId = 1,
							MarkaId = arac.MarkaId,
							ModelId = arac.ModelId,
							Km = arac.Km,
							BireyselMi = (arac.AracTuruId == 19),
							//todo bireysel/kurumsal kaydini elle id vermeden nasil alabilirim?

						});
						AracOzellik aracOzellikDonanim = aracDb.AracOzellikleri.Add(new AracOzellik()
						{
							AracId = eklenenArac.Id,
							OzellikDetayId = arac.DonanimId,
						});
						AracOzellik aracOzellikYakit = aracDb.AracOzellikleri.Add(new AracOzellik()
						{
							AracId = eklenenArac.Id,
							OzellikDetayId = arac.YakitTipiId,
						});
						AracOzellik aracOzellikGovde = aracDb.AracOzellikleri.Add(new AracOzellik()
						{
							AracId = eklenenArac.Id,
							OzellikDetayId = arac.GovdeTipiId,
						});
						AracOzellik aracOzellikVites = aracDb.AracOzellikleri.Add(new AracOzellik()
						{
							AracId = eklenenArac.Id,
							OzellikDetayId = arac.VitesTipiId,
						});
						AracOzellik aracOzellikRenk = aracDb.AracOzellikleri.Add(new AracOzellik()
						{
							AracId = eklenenArac.Id,
							OzellikDetayId = arac.RenkId,
						});
						AracOzellik aracOzellikTur = aracDb.AracOzellikleri.Add(new AracOzellik()
						{
							AracId = eklenenArac.Id,
							OzellikDetayId = arac.AracTuruId,
						});
						AracOzellik aracOzellikVersiyon = aracDb.AracOzellikleri.Add(new AracOzellik()
						{
							AracId = eklenenArac.Id,
							OzellikDetayId = arac.VersiyonTipiId,
						});
						
						AracStatu aracStatu = aracDb.AracStatu.Add(new AracStatu()
						{
							AracId = eklenenArac.Id,
							StatuId = arac.StatuId,
							Tarih = DateTime.Now
						});
						AracFiyat aracFiyat = aracDb.AracFiyatlari.Add(new AracFiyat()
						{
							AracId = eklenenArac.Id,
							Fiyat = arac.Fiyat,
							Tarih = DateTime.Now
						});

						aracDb.SaveChanges();
					}

					scope.Complete();
					return new SuccessResult("Araç kaydedildi");

				}
				catch (Exception ex)
				{
					scope.Complete();
					return new ErrorResult("Araç kaydedilemedi!");
				}
			}
		}

		public Result AracGuncelle(AracEklemeDetayVM arac)
		{
			using (TransactionScope scope = new TransactionScope())
			{
				try
				{
					using (AracIhaleContext aracDb = new AracIhaleContext())
					{
						Arac guncellenecekArac = aracDb.Araclar.Where(a => a.Id == arac.AracId).SingleOrDefault();

						guncellenecekArac.Yil = arac.Yil;
						guncellenecekArac.Plaka = arac.Plaka;
						guncellenecekArac.KullaniciId = 1;
						guncellenecekArac.MarkaId = arac.MarkaId;

						Arac eklenenArac = aracDb.Araclar.Add(new Arac()
						{
							Yil = arac.Yil,
							Plaka = arac.Plaka,
							KullaniciId = 1,
							MarkaId = arac.MarkaId,
							ModelId = arac.ModelId,
							Km = arac.Km,
							BireyselMi = (arac.AracTuruId == 19),
							//todo bireysel/kurumsal kaydini elle id vermeden nasil alabilirim?

						});
						AracOzellik aracOzellikDonanim = aracDb.AracOzellikleri.Add(new AracOzellik()
						{
							AracId = eklenenArac.Id,
							OzellikDetayId = arac.DonanimId,
						});
						AracOzellik aracOzellikYakit = aracDb.AracOzellikleri.Add(new AracOzellik()
						{
							AracId = eklenenArac.Id,
							OzellikDetayId = arac.YakitTipiId,
						});
						AracOzellik aracOzellikGovde = aracDb.AracOzellikleri.Add(new AracOzellik()
						{
							AracId = eklenenArac.Id,
							OzellikDetayId = arac.GovdeTipiId,
						});
						AracOzellik aracOzellikVites = aracDb.AracOzellikleri.Add(new AracOzellik()
						{
							AracId = eklenenArac.Id,
							OzellikDetayId = arac.VitesTipiId,
						});
						AracOzellik aracOzellikRenk = aracDb.AracOzellikleri.Add(new AracOzellik()
						{
							AracId = eklenenArac.Id,
							OzellikDetayId = arac.RenkId,
						});
						AracOzellik aracOzellikTur = aracDb.AracOzellikleri.Add(new AracOzellik()
						{
							AracId = eklenenArac.Id,
							OzellikDetayId = arac.AracTuruId,
						});
						AracOzellik aracOzellikVersiyon = aracDb.AracOzellikleri.Add(new AracOzellik()
						{
							AracId = eklenenArac.Id,
							OzellikDetayId = arac.VersiyonTipiId,
						});

						AracStatu aracStatu = aracDb.AracStatu.Add(new AracStatu()
						{
							AracId = eklenenArac.Id,
							StatuId = arac.StatuId,
							Tarih = DateTime.Now
						});
						AracFiyat aracFiyat = aracDb.AracFiyatlari.Add(new AracFiyat()
						{
							AracId = eklenenArac.Id,
							Fiyat = arac.Fiyat,
							Tarih = DateTime.Now
						});

						aracDb.SaveChanges();
					}

					scope.Complete();
					return new SuccessResult("Araç kaydedildi");

				}
				catch (Exception ex)
				{
					scope.Complete();
					return new ErrorResult("Araç kaydedilemedi!");
				}
			}
		}
	}
}
