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
using System.Web;

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
							BireyselMi = arac.BireyselVeyaFirmaId == (int)(UyeTurleri.Bireysel),
							UyeId = UyeTipineGoreUyeIdGetir(, ),
							Aciklama = arac.Aciklama
						});




						aracDb.AracOzellikleri.Add(new AracOzellik()
						{
							AracId = eklenenArac.Id,
							OzellikDetayId = arac.DonanimId,
						});
						aracDb.AracOzellikleri.Add(new AracOzellik()
						{
							AracId = eklenenArac.Id,
							OzellikDetayId = arac.YakitTipiId,
						});
						aracDb.AracOzellikleri.Add(new AracOzellik()
						{
							AracId = eklenenArac.Id,
							OzellikDetayId = arac.GovdeTipiId,
						});
						aracDb.AracOzellikleri.Add(new AracOzellik()
						{
							AracId = eklenenArac.Id,
							OzellikDetayId = arac.VitesTipiId,
						});
						aracDb.AracOzellikleri.Add(new AracOzellik()
						{
							AracId = eklenenArac.Id,
							OzellikDetayId = arac.RenkId,
						});
						aracDb.AracOzellikleri.Add(new AracOzellik()
						{
							AracId = eklenenArac.Id,
							OzellikDetayId = arac.AracTuruId,
						});
						aracDb.AracOzellikleri.Add(new AracOzellik()
						{
							AracId = eklenenArac.Id,
							OzellikDetayId = arac.VersiyonTipiId,
						});

						aracDb.AracStatu.Add(new AracStatu()
						{
							AracId = eklenenArac.Id,
							StatuId = arac.StatuId,
							Tarih = DateTime.Now,
						});
						aracDb.AracFiyatlari.Add(new AracFiyat()
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
				catch
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
						Arac guncellenecekArac = aracDb.Araclar.SingleOrDefault(a => a.Id == arac.AracId);

						guncellenecekArac.Yil = arac.Yil;
						guncellenecekArac.Plaka = arac.Plaka;
						guncellenecekArac.KullaniciId = arac.KaydedenKullaniciId;
						guncellenecekArac.MarkaId = arac.MarkaId;
						guncellenecekArac.ModelId = arac.ModelId;
						guncellenecekArac.Km = arac.Km;
						guncellenecekArac.BireyselMi = arac.BireyselVeyaFirmaId == (int)(UyeTurleri.Bireysel);
						guncellenecekArac.UyeId = arac.BireyselVeyaFirmaId;
						guncellenecekArac.ModifiedDate = arac.ModifiedDate;
						guncellenecekArac.ModifiedBy = arac.ModifiedBy;

						var guncellenecekAracOzellik = from ao in aracDb.AracOzellikleri
													   join od in aracDb.OzellikDetaylari on ao.OzellikDetayId equals od.OzellikDetayId
													   join oz in aracDb.Ozellikler on od.OzellikId equals oz.OzellikId
													   where ao.AracId == arac.AracId
													   select new
													   {
														   aracOzellik = ao,
														   ozellikDetay = od,
														   ozellik = oz
													   };



						foreach (var item in guncellenecekAracOzellik)
						{
							if (item.ozellik.OzellikId == (int)(AracOzellikleri.GovdeTipi))
							{
								item.ozellikDetay.OzellikDetayId = arac.GovdeTipiId;
							}
							if (item.ozellik.OzellikId == (int)(AracOzellikleri.VitesTipi))
							{
								item.ozellikDetay.OzellikDetayId = arac.VitesTipiId;
							}
							if (item.ozellik.OzellikId == (int)(AracOzellikleri.YakitTipi))
							{
								item.ozellikDetay.OzellikDetayId = arac.YakitTipiId;
							}
							if (item.ozellik.OzellikId == (int)AracOzellikleri.OpsiyonelDonanim)
							{
								item.ozellikDetay.OzellikDetayId = arac.DonanimId;
							}
							if (item.ozellik.OzellikId == (int)(AracOzellikleri.Renk))
							{
								item.ozellikDetay.OzellikDetayId = arac.RenkId;
							}
							if (item.ozellik.OzellikId == (int)(AracOzellikleri.Versiyon))
							{
								item.ozellikDetay.OzellikDetayId = arac.VersiyonTipiId;
							}
						}

						if ((AracStatuKontrol(arac.StatuId, arac.AracId)))
						{
							aracDb.AracStatu.Add(new AracStatu()
							{
								AracId = guncellenecekArac.Id,
								StatuId = arac.StatuId,
								Tarih = DateTime.Now,
								ModifiedBy = arac.ModifiedBy,
								ModifiedDate = arac.ModifiedDate,
							});
						}

						if ((AracFiyatKontrol(arac.Fiyat, arac.AracId)))
						{
							aracDb.AracFiyatlari.Add(new AracFiyat()
							{
								AracId = guncellenecekArac.Id,
								Fiyat = arac.Fiyat,
								Tarih = DateTime.Now,
								ModifiedDate = arac.ModifiedDate,
								ModifiedBy = arac.ModifiedBy
							});
						}


						aracDb.SaveChanges();
					}

					scope.Complete();
					return new SuccessResult("Araç güncellendi");

				}
				catch
				{
					scope.Complete();
					return new ErrorResult("Araç güncellenemedi!");
				}
			}
		}

		/// <summary>
		/// kullanicinin girdigi ffiyat bilgisini aracin son fiyat bilgisiyle karsilastirir. fiyat degisikligi yapildiysa son fiyati isdeleted = true yapar ve fiyat degisti diye true sonuc doner. 
		/// </summary>
		/// <param name="fiyat"></param>
		/// <param name="aracId"></param>
		/// <returns></returns>
		public bool AracFiyatKontrol(decimal fiyat, int aracId)
		{
			using (var db = new AracIhaleContext())
			{
				var sonFiyat = db.AracFiyatlari
					.Where(f => f.AracId == aracId && f.IsActive)
					.OrderByDescending(f => f.Tarih)
					.FirstOrDefault();

				if (sonFiyat != null && (fiyat != sonFiyat.Fiyat))
				{
					sonFiyat.IsActive = false;
					sonFiyat.IsDeleted = true;
				}
				return true;
			}
		}
		public bool AracStatuKontrol(int statuId, int aracId)
		{
			using (var db = new AracIhaleContext())
			{
				var sonStatu = db.AracStatu
					.Where(f => f.AracId == aracId && f.IsActive)
					.OrderByDescending(f => f.Tarih)
					.FirstOrDefault();

				if (sonStatu != null && sonStatu.Statu.StatuId != statuId)
				{
					sonStatu.IsActive = false;
					sonStatu.IsDeleted = true;
				}
				return true;
			}

		}

		public int UyeTipineGoreUyeIdGetir(int uyeTipi, int uyeId)
		{
			using (var db = new AracIhaleContext())
			{
				switch ((UyeTurleri)uyeTipi)
				{
					case UyeTurleri.Bireysel:
						var bireyselUye = db.BireyselUyeler.FirstOrDefault(x => x.Id == uyeId);
						return bireyselUye != null ? bireyselUye.UyeId : 0;
					case UyeTurleri.Kurumsal:
						var kurumsalUye = db.KurumsalUyeler.FirstOrDefault(x => x.Id == uyeId);
						return kurumsalUye != null ? kurumsalUye.UyeId : 0;
					default:
						return 0;
				}
			}
			
		}

	}
}
