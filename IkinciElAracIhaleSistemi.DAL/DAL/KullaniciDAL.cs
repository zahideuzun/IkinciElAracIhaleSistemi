﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Transactions;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.App.Results;
using IkinciElAracIhaleSistemi.App.Results.Bases;
using IkinciElAracIhaleSistemi.DAL.Context;
using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemi.Entities.VM;

namespace IkinciElAracIhaleSistemi.DAL.DAL
{
	public class KullaniciDAL
	{
		public List<KullaniciRolVM> KullanicilariRoluneGoreGetir()
		{
			using (AracIhaleContext aracDb = new AracIhaleContext())
			{
				return (from u in aracDb.Kullanicilar
						where u.IsActive == true
					select new KullaniciRolVM()
					{
						KullaniciId = u.KullaniciId,
						KullaniciIsim = u.Isim,
						KullaniciSoyisim = u.Soyisim,
						KullaniciAdi = u.KullaniciAdi,
						RolAdi = u.Rol.RolAdi,
						RolId = u.RolId,
						KullaniciSifre = u.Sifre,
						KullaniciMail = u.Mail,
						KullaniciTelefon = u.Telefon,

					}).ToList();
			}
		}

		/// <summary>
		/// giris yapan kullanici bilgilerini dbden gelen kullaniciyla karsilastiriyoruz
		/// </summary>
		/// <param name="vm"></param>
		/// <returns></returns>
		public KullaniciRolVM KullaniciKontrol(GirisVM vm)
		{
			using (AracIhaleContext aracDb = new AracIhaleContext())
			{
				KullaniciRolVM kullanici = (from u in aracDb.Kullanicilar
					where (u.KullaniciAdi == vm.KullaniciAdi || u.Mail == vm.Mail) && u.Sifre == vm.Sifre
					select new KullaniciRolVM()
					{
						KullaniciAdi = u.KullaniciAdi,
						KullaniciSifre = u.Sifre,
						KullaniciMail = u.Mail,
						RolAdi = u.Rol.RolAdi,
						RolId = u.RolId,
						KullaniciIsim = u.Isim,
						KullaniciSoyisim = u.Soyisim
					}).SingleOrDefault();
				return kullanici;
			}
		}

		public Result KullaniciEkle(KullaniciRolVM kullanici)
		{
			using (TransactionScope scope = new TransactionScope())
			{
				try
				{
					IletisimDAL iletisimTurleri = new IletisimDAL();

					using (AracIhaleContext aracDb = new AracIhaleContext())
					{
						Kullanici eklenenKullanici = aracDb.Kullanicilar.Add(new Kullanici()
						{
							KullaniciAdi = kullanici.KullaniciAdi,
							Mail = kullanici.KullaniciMail,
							Isim = kullanici.KullaniciIsim,
							Soyisim = kullanici.KullaniciSoyisim,
							Sifre = kullanici.KullaniciSifre,
							Telefon = kullanici.KullaniciTelefon,
							RolId = kullanici.RolId,
							//todo created by
						});

						var telefonId = Convert.ToInt16(IletisimTurleri.Telefon);
						var mailId = Convert.ToInt16(IletisimTurleri.Mail);

						var iletisimListesi = iletisimTurleri.IletisimTurleriniGetir()
							.Where(item => item.Id == telefonId || item.Id == mailId)
							.ToList();

						foreach (var item in iletisimListesi)
						{
							var kullaniciIletisim = new KullaniciIletisim()
							{
								IletisimId = item.Id,
								KullaniciId = eklenenKullanici.KullaniciId,
							};

							if (item.Id == telefonId)
							{
								kullaniciIletisim.IletisimBilgi = kullanici.KullaniciTelefon;
							}
							else if (item.Id == mailId)
							{
								kullaniciIletisim.IletisimBilgi = kullanici.KullaniciMail;
							}

							aracDb.KullaniciIletisimleri.Add(kullaniciIletisim);
						}

						aracDb.SaveChanges();
					}

					scope.Complete();
					return new SuccessResult("Kullanıcı kaydedildi");

				}
				catch (Exception ex)
				{
					scope.Complete();
					return new ErrorResult("Kullanıcı kaydedilemedi!");
				}
			}
		}

		public KullaniciRolVM IdyeGoreKullaniciGetir(int? id)
		{
			using (AracIhaleContext aracDb = new AracIhaleContext())
			{
				return (from u in aracDb.Kullanicilar
						where u.KullaniciId == id
					select new KullaniciRolVM()
					{
						KullaniciId = u.KullaniciId,
						KullaniciIsim = u.Isim,
						KullaniciSoyisim = u.Soyisim,
						KullaniciAdi = u.KullaniciAdi,
						RolAdi = u.Rol.RolAdi,
						RolId = u.RolId,
						KullaniciSifre = u.Sifre,
						KullaniciMail = u.Mail,
						KullaniciTelefon = u.Telefon,

					}).SingleOrDefault();
			}
		}

		public Result KullaniciGuncelle(KullaniciRolVM kullanici)
		{
			using (TransactionScope scope = new TransactionScope())
			{
				try
				{
					using (AracIhaleContext aracDb = new AracIhaleContext())
					{
						var guncellenecekKullanici = aracDb.Kullanicilar.Find(kullanici.KullaniciId);
						if (guncellenecekKullanici != null)
						{
							//aracDb.Kullanicilar.Attach(guncellenecekKullanici);
							aracDb.Entry(guncellenecekKullanici).State = EntityState.Modified;
							guncellenecekKullanici.KullaniciAdi = kullanici.KullaniciAdi;
							guncellenecekKullanici.Mail = kullanici.KullaniciMail;
							guncellenecekKullanici.Isim = kullanici.KullaniciIsim;
							guncellenecekKullanici.Soyisim = kullanici.KullaniciSoyisim;
							guncellenecekKullanici.Telefon = kullanici.KullaniciTelefon;
							guncellenecekKullanici.RolId = kullanici.RolId;
							guncellenecekKullanici.Sifre = kullanici.KullaniciSifre;
							//todo modified by
						}

						var telefonId = Convert.ToInt16(IletisimTurleri.Telefon);
						var mailId = Convert.ToInt16(IletisimTurleri.Mail);

						
						var guncellenecekIletisim = aracDb.KullaniciIletisimleri
							.Where(x => x.KullaniciId == kullanici.KullaniciId).ToList();


						foreach (var item in guncellenecekIletisim)
						{
							if (item.IletisimId == telefonId)
							{
								item.IletisimBilgi = guncellenecekKullanici.Telefon;
							}
							else if (item.IletisimId == mailId)
							{
								item.IletisimBilgi = guncellenecekKullanici.Mail;
							}
						}
						aracDb.SaveChanges();
					}
					scope.Complete();
					return new SuccessResult("Kullanıcı güncellendi!");
				}
				catch (Exception ex)
				{

					scope.Complete();
					return new ErrorResult("Kullanıcı güncellenemedi!");
				}
			}
		}

		public Result KullaniciSil(int? id)
		{
			using (TransactionScope scope = new TransactionScope())
			{
				try
				{
					using (AracIhaleContext aracDb = new AracIhaleContext())
					{
						
						var silinecekKullanici = aracDb.Kullanicilar.Find(id);
						if (silinecekKullanici != null)
						{
							silinecekKullanici.IsActive = false;
							silinecekKullanici.IsDeleted = true;
							silinecekKullanici.ModifiedDate = DateTime.Now;
						}

						var telefonId = Convert.ToInt16(IletisimTurleri.Telefon);
						var mailId = Convert.ToInt16(IletisimTurleri.Mail);

						var guncellenecekIletisim = aracDb.KullaniciIletisimleri
							.Where(x => x.KullaniciId == id).ToList();

						foreach (var item in guncellenecekIletisim)
						{
							if (item.IletisimId == telefonId)
							{
								item.IsActive = false;
								item.IsDeleted = true;
							}
							else if (item.IletisimId == mailId)
							{
								item.IsActive = false;
								item.IsDeleted = true;
							}
						}

						//todo savechanges contextte override edildi. Entry.State kullanarak yap?? 
						aracDb.SaveChanges();
					}
					scope.Complete();
					return new SuccessResult("Kullanıcı silindi!");
				}
				catch (Exception ex)
				{
					scope.Complete();
					return new ErrorResult("Kullanıcı silinemedi!");
				}
			}
		}

	}
}
