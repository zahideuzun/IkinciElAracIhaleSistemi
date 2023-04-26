using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.DAL.Context;
using IkinciElAracIhaleSistemi.Entities.VM.Arac;

namespace IkinciElAracIhaleSistemi.DAL.DAL
{
	public class AracDAL
	{
		public List<AracBilgileriVM> AraclariGetir()
		{
			using (AracIhaleContext db = new AracIhaleContext())
			{
				var liste= (from k in db.Araclar
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
	}
}
