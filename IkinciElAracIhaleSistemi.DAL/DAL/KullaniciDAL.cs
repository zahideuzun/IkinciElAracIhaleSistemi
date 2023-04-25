using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		public KullaniciRolVM KullaniciKontrol(LoginVM vm)
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

		public int KullaniciEkle(KullaniciRolVM kullanici)
		{
			try
			{
				using (AracIhaleContext aracDb = new AracIhaleContext())
				{
					aracDb.Kullanicilar.Add(new Kullanici()
					{
						KullaniciAdi = kullanici.KullaniciAdi,
						Mail = kullanici.KullaniciMail,
						Isim = kullanici.KullaniciIsim,
						Soyisim = kullanici.KullaniciSoyisim,
						Sifre = kullanici.KullaniciSifre,
						Telefon = kullanici.KullaniciTelefon,
						RolId = kullanici.RolId,
					});
					return aracDb.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				//todo buraya duserse napacagina karar ver
				return -1;
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

		public int KullaniciGuncelle(KullaniciRolVM kullanici)
		{
			try
			{
				using (AracIhaleContext aracDb = new AracIhaleContext())
				{
					var guncellenecekKullanici = aracDb.Kullanicilar.Find(kullanici.KullaniciId);
					if (guncellenecekKullanici != null)
					{
						aracDb.Kullanicilar.Attach(guncellenecekKullanici);
						aracDb.Entry(kullanici).State = EntityState.Modified;
						kullanici.KullaniciAdi = guncellenecekKullanici.KullaniciAdi;
						kullanici.KullaniciMail = guncellenecekKullanici.Mail;
						kullanici.KullaniciIsim = guncellenecekKullanici.Isim;
						kullanici.KullaniciSoyisim = guncellenecekKullanici.Soyisim;
						kullanici.KullaniciTelefon = guncellenecekKullanici.Telefon;
						kullanici.RolId = guncellenecekKullanici.RolId;
						kullanici.KullaniciSifre = guncellenecekKullanici.Sifre;
					}

					return aracDb.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				//todo buraya duserse napacagina karar ver
				return -1; 
			}
		}

		public int KullaniciSil(KullaniciRolVM kullanici)
		{
			try
			{
				using (AracIhaleContext aracDb = new AracIhaleContext())
				{
					var silinecekKullanici = aracDb.Kullanicilar.Find(kullanici.KullaniciId);
					if (silinecekKullanici != null)
					{
						aracDb.Entry(kullanici).State = EntityState.Deleted;
					}
					//savechanges contextte override edildi.
					return aracDb.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				//todo buraya duserse napacagina karar ver
				return -1;
			}
		}

	}
}
