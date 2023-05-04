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
using System.Web.Mvc;

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
					where k.IsActive
					orderby k.CreatedDate descending 
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
		public AracEklemeDetayVM GuncellenecekAracBilgisiniGetir(int? id)
		{
			using (AracIhaleContext db = new AracIhaleContext())
			{
				AracEklemeDetayVM arac = (from k in db.Araclar
										  join mr in db.Markalar on k.MarkaId equals mr.MarkaId
										  join md in db.Modeller on k.ModelId equals md.ModelId
										  join ast in db.AracStatu on k.Id equals ast.AracId
										  join st in db.Status on ast.StatuId equals st.StatuId
										  join af in db.AracFiyatlari on k.Id equals af.AracId
										  join ao in db.AracOzellikleri on k.Id equals ao.AracId
										  join ozd in db.OzellikDetaylari on ao.OzellikDetayId equals ozd.OzellikDetayId
										  join oz in db.Ozellikler on ozd.OzellikId equals oz.OzellikId
										  where k.Id == id
										  select new AracEklemeDetayVM()
										  {
											  AracId = k.Id,
											  Plaka = k.Plaka,
											  Fiyat = af.Fiyat,
											  StatuId = ast.StatuId,
											  Yil = k.Yil,
											  Km = k.Km,
											  MarkaId = mr.MarkaId,
											  ModelId = md.ModelId,
											  Aciklama = k.Aciklama,
											  BireyselVeyaFirmaId = k.UyeId
										  }).FirstOrDefault();

				var guncellenecekAracOzellik = (from ao in db.AracOzellikleri
												join od in db.OzellikDetaylari on ao.OzellikDetayId equals od.OzellikDetayId
												join oz in db.Ozellikler on od.OzellikId equals oz.OzellikId
												where ao.AracId == arac.AracId
												select new
												{
													aracOzellik = ao,
													ozellikDetay = od,
													ozellik = oz
												});
				foreach (var item in guncellenecekAracOzellik)
				{
					switch (item.ozellik.OzellikId)
					{
						case (int)(AracOzellikleri.GovdeTipi):
							arac.GovdeTipiId = item.ozellikDetay.OzellikDetayId;
							break;
						case (int)(AracOzellikleri.VitesTipi):
							arac.VitesTipiId = item.ozellikDetay.OzellikDetayId;
							break;
						case (int)(AracOzellikleri.YakitTipi):
							arac.YakitTipiId = item.ozellikDetay.OzellikDetayId;
							break;
						case (int)AracOzellikleri.OpsiyonelDonanim:
							arac.DonanimId = item.ozellikDetay.OzellikDetayId;
							break;
						case (int)(AracOzellikleri.Renk):
							arac.RenkId = item.ozellikDetay.OzellikDetayId;
							break;
						case (int)(AracOzellikleri.Versiyon):
							arac.VersiyonTipiId = item.ozellikDetay.OzellikDetayId;
							break;
						case (int)(AracOzellikleri.AracTuru):
							arac.AracTuruId = item.ozellikDetay.OzellikDetayId;
							break;
					}
				}
				return arac;
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
							BireyselMi = arac.AracTuruId == (int)(UyeTurleri.Bireysel),
							Aciklama = arac.Aciklama
						});
						eklenenArac.UyeId = eklenenArac.BireyselMi ? UyeTipineGoreUyeIdGetir((int)UyeTurleri.Bireysel, arac.BireyselVeyaFirmaId) : UyeTipineGoreUyeIdGetir((int)UyeTurleri.Kurumsal, arac.BireyselVeyaFirmaId);

						var sorgu = aracDb.KurumsalUyeler.SingleOrDefault(a => a.UyeId == eklenenArac.UyeId);
						if (sorgu != null)
						{
							var firmaId = sorgu.FirmaId;
							aracDb.Stoklar.Add(new Stok()
							{
								AracId = eklenenArac.Id,
								FirmaId = firmaId,
								Tarih = DateTime.Now
							});
						}

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
						guncellenecekArac.ModifiedDate = arac.ModifiedDate;
						guncellenecekArac.ModifiedBy = arac.ModifiedBy;
						guncellenecekArac.Aciklama = arac.Aciklama;

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
							switch (item.ozellik.OzellikId)
							{
								case (int)(AracOzellikleri.GovdeTipi):
									item.aracOzellik.OzellikDetayId = arac.GovdeTipiId;
									break;
								case (int)(AracOzellikleri.VitesTipi):
									item.aracOzellik.OzellikDetayId = arac.VitesTipiId;
									break;
								case (int)(AracOzellikleri.YakitTipi):
									item.aracOzellik.OzellikDetayId = arac.YakitTipiId;
									break;
								case (int)AracOzellikleri.OpsiyonelDonanim:
									item.aracOzellik.OzellikDetayId = arac.DonanimId;
									break;
								case (int)(AracOzellikleri.Renk):
									arac.RenkId = item.aracOzellik.OzellikDetayId;
									break;
								case (int)(AracOzellikleri.Versiyon):
									item.aracOzellik.OzellikDetayId = arac.VersiyonTipiId;
									break;
							}
						}

						if (!(AracStatuKontrol(arac.StatuId, arac.AracId)))
						{
							aracDb.AracStatu.Add(new AracStatu()
							{
								AracId = guncellenecekArac.Id,
								StatuId = arac.StatuId,
								Tarih = DateTime.Now,
								IsActive = false,
								IsDeleted = true,
								ModifiedBy = arac.ModifiedBy,
								ModifiedDate = arac.ModifiedDate,
							});
						}

						if (!(AracFiyatKontrol(arac.Fiyat, arac.AracId)))
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

		public Result AracSil(int id)
		{
			using (TransactionScope scope = new TransactionScope())
			{
				try
				{
					using (AracIhaleContext aracDb = new AracIhaleContext())
					{

						var silinecekArac = aracDb.Araclar.Find(id);
						if (silinecekArac != null)
						{
							silinecekArac.IsActive = false;
							silinecekArac.IsDeleted = true;
							silinecekArac.ModifiedDate = DateTime.Now;
						}

						var silinecekAracFiyat = aracDb.AracFiyatlari.SingleOrDefault(x => x.AracId== id && x.IsActive);
						if (silinecekAracFiyat != null)
						{
							silinecekAracFiyat.IsActive = false;
							silinecekAracFiyat.IsDeleted = true;
							silinecekAracFiyat.ModifiedDate = DateTime.Now;
						}

						var silinecekAracOzellikleri = aracDb.AracOzellikleri.Where(x => x.AracId == id && x.IsActive).ToList();

						foreach (var aracOzellik in silinecekAracOzellikleri)
						{
							aracOzellik.IsActive = false;
							aracOzellik.IsDeleted = true;
							aracOzellik.ModifiedDate = DateTime.Now;
						}
						var silinecekAracStatu = aracDb.AracStatu.SingleOrDefault(x => x.AracId == id && x.IsActive);
						if (silinecekAracStatu != null)
						{
							silinecekAracStatu.IsActive = false;
							silinecekAracStatu.IsDeleted = true;
							silinecekAracStatu.ModifiedDate = DateTime.Now;
						}
						var silinecekAracTramer = aracDb.AracTramerleri.SingleOrDefault(x => x.AracId == id && x.IsActive);
						if (silinecekAracTramer != null)
						{				 
							silinecekAracTramer.IsActive = false;
							silinecekAracTramer.IsDeleted = true;
						}
						var silinecekAracTramerDetayi = aracDb.AracTramerDetaylari.SingleOrDefault(x => x.AracTramerId == silinecekAracTramer.AracTramerId && x.IsActive);
						if (silinecekAracTramerDetayi != null)
						{					   
							silinecekAracTramerDetayi.IsActive = false;
							silinecekAracTramerDetayi.IsDeleted = true;
						}


						//todo savechanges contextte override edildi. Entry.State kullanarak yap?? 
						aracDb.SaveChanges();
					}
					scope.Complete();
					return new SuccessResult("Araç silindi!");
				}
				catch (Exception ex)
				{
					scope.Complete();
					return new ErrorResult("Araç silinemedi!");
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

		/// <summary>
		/// kullanicinin girdigi statu bilgisini aracin son statu bilgisiyle karsilastirir. statu degisikligi yapildiysa son statuyu isdeleted = true yapar ve statu degisti diye true sonuc doner. 
		/// </summary>
		/// <param name="statuId"></param>
		/// <param name="aracId"></param>
		/// <returns></returns>
		public bool AracStatuKontrol(int statuId, int aracId)
		{
			using (var db = new AracIhaleContext())
			{
				var sonStatu = db.AracStatu
					.Where(f => f.AracId == aracId && f.IsActive)
					.OrderByDescending(f => f.Tarih)
					.FirstOrDefault();

				if (sonStatu != null && sonStatu.StatuId != statuId)
				{
					sonStatu.IsActive = false;
					sonStatu.IsDeleted = true;
					return false;
				}

				return true;
			}

		}

		/// <summary>
		/// arac eklemede kurumsal ya da bireysel secilen uyelerin uye tablosundaki idsini getirir.
		/// </summary>
		/// <param name="uyeTipi"></param>
		/// <param name="uyeId"></param>
		/// <returns></returns>
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
