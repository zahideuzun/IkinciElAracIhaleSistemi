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

                        eklenenIhale.UyeId = ihaleEkle.IhaleTuruId == (int)(IhaleTurleri.Bireysel) ? UyeTipineGoreUyeIdGetir((int)UyeTurleri.Bireysel, ihaleEkle.BireyselVeyaFirmaId) : UyeTipineGoreUyeIdGetir((int)UyeTurleri.Kurumsal, ihaleEkle.BireyselVeyaFirmaId);

                        aracDb.IhaleStatuleri.Add(new IhaleStatu()
                        {
                            Tarih = DateTime.Now,
                            IhaleId = ihaleEkle.IhaleId,
                            StatuId = ihaleEkle.StatuId
                        });


                        aracDb.SaveChanges();
                    }

                    scope.Complete();
                    return new SuccessResult("İhale kaydedildi");

                }
                catch
                {
                    scope.Complete();
                    return new ErrorResult("İhale kaydedilemedi!");
                }
            }
        }

        public IhaleEkleVM IdyeGoreIhaleBilgileriniGetir(int? id)
        {
            using (AracIhaleContext db = new AracIhaleContext())
            {
                var ihale = (from ih in db.Ihaleler
                    join ist in db.IhaleStatuleri on ih.Id equals ist.IhaleId
                    where ih.Id == id
                    select new IhaleEkleVM()
                    {
                        IhaleAdi = ih.IhaleAdi,
                        IhaleTuru = ih.IhaleTuru.IhaleTuruAdi,
                        BireyselVeyaFirmaId = ih.UyeId,
                        BaslangicTarihi = ih.IhaleBaslangicTarihi,
                        BaslangicSaati = ih.BaslangicSaat,
                        BitisSaati = ih.BitisSaat,
                        BitisTarihi = ih.IhaleBitisTarihi,
                        StatuId = ist.StatuId,
                    }).FirstOrDefault();
                return ihale;
            }
        }

        public List<AracBilgileriVM> IhaleIdyeGoreFirmaBilgileriniGetir(int? id)
        {
            using (AracIhaleContext db = new AracIhaleContext())
            {
                int ihaleyeAitUyeId = (db.Ihaleler.FirstOrDefault(a => a.Id == id).UyeId);
                var aracListesi = db.Araclar
                    .Where(a => a.UyeId == ihaleyeAitUyeId && a.IsActive)
                    .Select(a=> new AracBilgileriVM()
                    {
                        AracId = a.Id,
                        Plaka = a.Plaka,
                        MarkaAdi = a.Marka.MarkaAdi,
                        ModelAdi = a.Model.ModelAdi,
                        BireyselMi = a.BireyselMi ? "Bireysel" : "Kurumsal",
                        KaydedenKullanici = a.Kullanici.Isim,
                        KaydedilmeZamani = (DateTime)a.CreatedDate,
                    }).ToList();
                return aracListesi;
            }
        }
        public List<SelectListItem> FirmayaAitAracListesineDonustur(int? id)
        {
            var statuVm = new IhaleEkleVM();
            statuVm.IdyeGoreFirmalar = new IhaleDAL().IhaleIdyeGoreFirmaBilgileriniGetir(id)
                .Select(r => new SelectListItem()
                {
                    Value = r.AracId.ToString(),
                    Text = r.Plaka
                }).ToList();
            return statuVm.IdyeGoreFirmalar;
        }

        public Result IhaleyeAracEkle(IhaleEkleVM vm)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    using (AracIhaleContext aracDb = new AracIhaleContext())
                    {
                        AracIhale ihaleyeEklenenArac = aracDb.AracIhaleleri.Add(new AracIhale()
                        {
                            IhaleId = vm.IhaleId,
                            AracId = vm.AracId,
                            MinimumAlimFiyati = vm.MinimumAlimFiyati,
                            IhaleBaslangicFiyati = vm.IhaleBaslangicFiyati
                        });
                    }

                    scope.Complete();
                    return new SuccessResult("İhaleye araç kaydedildi");

                }
                catch
                {
                    scope.Complete();
                    return new ErrorResult("İhaleye araç kaydedilemedi!");
                }
            }
        }


        public int UyeTipineGoreUyeIdGetir(int uyeTipi, int uyeId)
        {
            using (var db = new AracIhaleContext())
            {
                switch ((UyeTurleri)uyeTipi)
                {
                    case UyeTurleri.Bireysel:
                        var bireyselUye = db.BireyselUyeler.FirstOrDefault(x => x.UyeId == uyeId);
                        return bireyselUye?.UyeId ?? 0;
                    case UyeTurleri.Kurumsal:
                        var kurumsalUye = db.KurumsalUyeler.FirstOrDefault(x => x.UyeId == uyeId);
                        return kurumsalUye?.UyeId ?? 0;
                    default:
                        return 0;
                }
            }

        }
        public bool IhaleStatuKontrol(int statuId, int ihaleId)
        {
            using (var db = new AracIhaleContext())
            {
                var sonStatu = db.IhaleStatuleri
                    .Where(f => f.IhaleId == ihaleId && f.IsActive)
                    .OrderByDescending(f => f.Tarih)
                    .FirstOrDefault();

                if (sonStatu != null && sonStatu.StatuId != statuId)
                {
                    sonStatu.IsActive = false;
                    sonStatu.IsDeleted = true;
                    db.SaveChanges();
                    return false;
                }

                return true;
            }

        }

        public Result IhaleBilgileriniGuncelle(IhaleEkleVM ihale)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    using (AracIhaleContext aracDb = new AracIhaleContext())
                    {
                        Ihale guncellenecekIhaleBilgisi = aracDb.Ihaleler.SingleOrDefault(a => a.Id == ihale.IhaleId);
                        guncellenecekIhaleBilgisi.IhaleBaslangicTarihi = ihale.BaslangicTarihi;
                        guncellenecekIhaleBilgisi.BaslangicSaat = ihale.BaslangicSaati;
                        guncellenecekIhaleBilgisi.IhaleBitisTarihi = ihale.BitisTarihi;
                        guncellenecekIhaleBilgisi.BitisSaat = ihale.BitisSaati;

                        if (!(IhaleStatuKontrol(ihale.StatuId, ihale.IhaleId)))
                        {
                            aracDb.IhaleStatuleri.Add(new IhaleStatu()
                            {
                                StatuId = ihale.StatuId,
                                Tarih = DateTime.Now,
                                IsActive = true,
                                IsDeleted = false,
                            });
                        }

                        aracDb.SaveChanges();

                    }
                    scope.Complete();
                    return new SuccessResult("İhale kaydedildi");
                }
                catch
                {
                    scope.Complete();
                    return new ErrorResult("İhale kaydedilemedi!");
                }
            }

        }

        
    }
}
