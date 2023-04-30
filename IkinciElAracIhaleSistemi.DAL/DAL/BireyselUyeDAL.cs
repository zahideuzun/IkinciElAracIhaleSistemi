using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using IkinciElAracIhaleSistemi.DAL.Context;
using IkinciElAracIhaleSistemi.Entities.VM;
using IkinciElAracIhaleSistemi.Entities.VM.Enum;

namespace IkinciElAracIhaleSistemi.DAL.DAL
{
	public class BireyselUyeDAL
	{
		public List<BireyselUyeVM> BireyselUyeleriGetir(UyeTurleri uyeTurleri)
		{
			using (AracIhaleContext aracDb = new AracIhaleContext())
			{
				return (from u in aracDb.Uyeler
					join ut in aracDb.UyeTurleri on u.UyeTuruId equals ut.UyeTuruId
					where u.IsActive && ut.UyeTuruAdi == uyeTurleri.ToString()
					select new BireyselUyeVM()
					{
						UyeId = u.Id,
						Isım = u.Isim,
						Soyisim = u.Soyisim,
						Mail = u.Email,
						Telefon = u.Telefon,
						Sifre = u.Sifre,

					}).ToList();
			}
		}
		public List<SelectListItem> BireyselUyeleriListeyeDonustur(UyeTurleri uyeTurleri)
		{
			var bireyselUyeler = new BireyselUyeDAL().BireyselUyeleriGetir(uyeTurleri)
				.Select(r => new SelectListItem()
				{
					Value = r.UyeId.ToString(),
					Text = r.Isım+" "+r.Soyisim,
				}).ToList();

			return bireyselUyeler;
		}
	}
}
