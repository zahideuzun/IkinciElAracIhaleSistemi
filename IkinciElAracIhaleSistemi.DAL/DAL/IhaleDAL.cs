using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.DAL.Context;
using IkinciElAracIhaleSistemi.Entities.VM;
using IkinciElAracIhaleSistemi.Entities.VM.Arac;

namespace IkinciElAracIhaleSistemi.DAL.DAL
{
    public class IhaleDAL
    {
        public List<IhaleVM> AraclariGetir()
        {
            using (AracIhaleContext db = new AracIhaleContext())
            {
                var liste = (from k in db.Ihaleler
                    join it in db.IhaleTurleri on k.IhaleTuruId equals it.IhaleTuruId
                    join ist in db.IhaleStatuleri on k.Id equals ist.IhaleId
                    join st in db.Status on ist.StatuId equals st.StatuId
                    where k.IsActive && ist.IsActive
                    orderby k.CreatedDate descending
                    select new IhaleVM()
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
