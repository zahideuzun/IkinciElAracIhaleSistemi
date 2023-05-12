using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Mvc;
using IkinciElAracIhaleSistemi.App.Results;
using IkinciElAracIhaleSistemi.App.Results.Bases;
using IkinciElAracIhaleSistemi.DAL.Context;
using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemi.Entities.VM;
using IkinciElAracIhaleSistemi.Entities.VM.Arac;
using IkinciElAracIhaleSistemi.Entities.VM.Enum;

namespace IkinciElAracIhaleSistemi.DAL.DAL
{
    public class IhaleDAL
    {
        public List<StatuVM> IhaleStatuleriniGetir()
        {
            using (var db = new AracIhaleContext())
            {
                var ihaleStatuleri = Enum.GetValues(typeof(IhaleStatuleri)).Cast<int>().ToArray();

                return db.Status
                    .Where(s => s.IsActive && ihaleStatuleri.Contains(s.StatuId))
                    .Select(s => new StatuVM
                    {
                        StatuId = s.StatuId,
                        StatuAdi = s.StatuAdi
                    }).ToList();
            }
        }
        public List<SelectListItem> StatuListesineDonustur()
        {
            var statuVm = new IhaleVM();
            statuVm.Statuler = new IhaleDAL().IhaleStatuleriniGetir()
                .Select(r => new SelectListItem()
                {
                    Value = r.StatuId.ToString(),
                    Text = r.StatuAdi
                }).ToList();
            return statuVm.Statuler;
        }

        public List<IhaleVM> IhaleTurleriniGetir()
        {
            using (var db = new AracIhaleContext())
            {
                return db.IhaleTurleri
                    .Where(s => s.IsActive)
                    .Select(s => new IhaleVM()
                    {
                        IhaleTuruId = s.IhaleTuruId,
                        IhaleTuru = s.IhaleTuruAdi
                    }).ToList();
            }
        }
        public List<SelectListItem> IhaleTuruListesineDonustur()
        {
            var statuVm = new IhaleVM();
            statuVm.IhaleTurleri = new IhaleDAL().IhaleTurleriniGetir()
                .Select(r => new SelectListItem()
                {
                    Value = r.IhaleTuruId.ToString(),
                    Text = r.IhaleTuru
                }).ToList();
            return statuVm.IhaleTurleri;
        }

        public List<IhaleVM> IhaleleriGetir()
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
                                 IhaleId = k.Id,
                                 IhaleAdi = k.IhaleAdi,
                                 IhaleTuru = k.IhaleTuruId == (int)IhaleTurleri.Bireysel ? "Bireysel" : "Kurumsal",
                                 BaslangicTarihi = k.IhaleBaslangicTarihi,
                                 BitisTarihi = k.IhaleBitisTarihi,
                                 Statu = st.StatuAdi,
                                 OlusturanKullanici = k.Kullanici.Isim,
                                 OlusturulmaTarihi = (DateTime)k.CreatedDate
                             }).ToList();
                return liste;

            }
        }

        public Result IhaleEkle(IhaleEkleVM ihaleEkle)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    using (AracIhaleContext aracDb = new AracIhaleContext())
                    {
                        Ihale eklenenIhale = aracDb.Ihaleler.Add(new Ihale()
                        {
                            IhaleAdi = ihaleEkle.IhaleAdi,
                            IhaleBaslangicTarihi = ihaleEkle.BaslangicTarihi,
                            IhaleBitisTarihi = ihaleEkle.BitisTarihi,
                            BaslangicSaat = ihaleEkle.BaslangicSaati,
                            BitisSaat = ihaleEkle.BitisSaati,
                            IhaleTuruId = ihaleEkle.IhaleTuruId,
                            KullaniciId = 1,
                        });

                        //eklenenIhale.UyeId = eklenenArac.BireyselMi ? UyeTipineGoreUyeIdGetir((int)UyeTurleri.Bireysel, arac.BireyselVeyaFirmaId) : UyeTipineGoreUyeIdGetir((int)UyeTurleri.Kurumsal, arac.BireyselVeyaFirmaId);


                        
                       

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
    }
}
