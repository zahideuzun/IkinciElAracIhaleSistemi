using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.DAL.Context;
using IkinciElAracIhaleSistemi.Entities.VM;



namespace IkinciElAracIhaleSistemi.DAL.DAL
{
	public class KullaniciDAL
	{
		AracIhaleContext aracDb = new AracIhaleContext();

		public List<KullaniciRolVM> KullanicilariRoluneGoreGetir()
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

		/// <summary>
		/// giris yapan kullanici bilgilerini dbden gelen kullaniciyla karsilastiriyoruz
		/// </summary>
		/// <param name="vm"></param>
		/// <returns></returns>
		public KullaniciRolVM KullaniciKontrol(LoginVM vm)
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
}
