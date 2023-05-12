using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                            Isim = u.Isim,
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
                    Text = r.Isim + " " + r.Soyisim,
                }).ToList();

            return bireyselUyeler;
        }

        public List<BireyselUyeVM> BireyselUyeleriListele()
        {
            using (AracIhaleContext aracDb = new AracIhaleContext())
            {
                return (from u in aracDb.Uyeler
                        join bu in aracDb.BireyselUyeler on u.Id equals bu.UyeId
                        where u.IsActive && u.IsDeleted == false
                        select new BireyselUyeVM()
                        {
                            UyeId = u.Id,
                            Isim = u.Isim,
                            Soyisim = u.Soyisim,
                            Mail = u.Email,
                            Telefon = u.Telefon,
                            Sifre = u.Sifre,
                            TcKimlik = bu.TcKimlikNo,
                            OnayliMi = bu.IsActive ? "Onaylı" : "Onaylanmadı",
                            RolId = bu.RolId
                        }).ToList();
            }
        }

        public void BireyselUyeOnay(int id)
        {
            using (AracIhaleContext aracDb = new AracIhaleContext())
            {
                var onaylanacakUye = aracDb.BireyselUyeler.FirstOrDefault(u => u.UyeId == id);
                onaylanacakUye.IsActive = true;
                onaylanacakUye.IsDeleted = false;
                aracDb.SaveChanges();
            }
        }

        public Result BireyselUyeEkle(BireyselUyeVM bireyselUye)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    IletisimDAL iletisimTurleri = new IletisimDAL();
                    using (AracIhaleContext aracDb = new AracIhaleContext())
                    {
                        Uye eklenenUye = aracDb.Uyeler.Add(new Uye()
                        {
                            Isim = bireyselUye.Isim,
                            Soyisim = bireyselUye.Soyisim,
                            Email = bireyselUye.Mail,
                            Telefon = bireyselUye.Telefon,
                            UyeTuruId = (aracDb.UyeTurleri.ToList()
                                .SingleOrDefault(a => a.UyeTuruAdi == UyeTurleri.Bireysel.ToString())).UyeTuruId,
                            Sifre = bireyselUye.Sifre
                        });

                        BireyselUye eklenenBireyselUye = aracDb.BireyselUyeler.Add(new BireyselUye()
                        {
                            UyeId = eklenenUye.Id,
                            TcKimlikNo = bireyselUye.TcKimlik,
                            RolId = (int)Roller.BireyselUye
                        });


                        var telefonId = Convert.ToInt16(IletisimTurleri.Telefon);
                        var mailId = Convert.ToInt16(IletisimTurleri.Mail);

                        var iletisimListesi = iletisimTurleri.IletisimTurleriniGetir()
                            .Where(item => item.Id == telefonId || item.Id == mailId)
                            .ToList();

                        foreach (var item in iletisimListesi)
                        {
                            var uyeIletisim = new UyeIletisim()
                            {
                                IletisimId = item.Id,
                                UyeId = eklenenBireyselUye.UyeId,
                            };

                            if (item.Id == telefonId)
                            {
                                uyeIletisim.IletisimBilgi = bireyselUye.Telefon;
                            }
                            else if (item.Id == mailId)
                            {
                                uyeIletisim.IletisimBilgi = bireyselUye.Mail;
                            }

                            aracDb.UyeIletisimleri.Add(uyeIletisim);
                        }

                        aracDb.SaveChanges();
                    }
                    scope.Complete();
                    return new SuccessResult("Bireysel Üye kaydedildi");

                }
                catch
                {
                    scope.Complete();
                    return new ErrorResult("Bireysel Üye kaydedilemedi");
                }
            }
        }

        public BireyselUyeVM IdyeGoreBireyselUyeGetir(int? id)
        {
            using (AracIhaleContext aracDb = new AracIhaleContext())
            {
                return (from u in aracDb.BireyselUyeler
                        join uy in aracDb.Uyeler on u.UyeId equals uy.Id
                        where uy.Id == id
                        select new BireyselUyeVM()
                        {
                            UyeId = u.UyeId,
                            Isim = uy.Isim,
                            Soyisim = uy.Soyisim,
                            Sifre = uy.Sifre,
                            Mail = uy.Email,
                            Telefon = uy.Telefon,
                            TcKimlik = u.TcKimlikNo

                        }).SingleOrDefault();
            }
        }

        public Result BireyselUyeGuncelle(BireyselUyeVM bireyselUye)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    using (AracIhaleContext aracDb = new AracIhaleContext())
                    {
                        var guncellenecekUyeBilgisi = aracDb.Uyeler.Find(bireyselUye.UyeId);
                        if (guncellenecekUyeBilgisi != null)
                        {
                            aracDb.Entry(guncellenecekUyeBilgisi).State = EntityState.Modified;
                            guncellenecekUyeBilgisi.Email = bireyselUye.Mail;
                            guncellenecekUyeBilgisi.Isim = bireyselUye.Isim;
                            guncellenecekUyeBilgisi.Soyisim = bireyselUye.Soyisim;
                            guncellenecekUyeBilgisi.Telefon = bireyselUye.Telefon;
                            guncellenecekUyeBilgisi.Sifre = bireyselUye.Sifre;
                            //todo modified by controllerda yap?
                        }

                        var guncellenecekBireyselUye =
                            aracDb.BireyselUyeler.SingleOrDefault(a => a.UyeId == bireyselUye.UyeId);
                        if (guncellenecekBireyselUye != null)
                        {
                            guncellenecekBireyselUye.TcKimlikNo = bireyselUye.TcKimlik;

                        }

                        var telefonId = Convert.ToInt16(IletisimTurleri.Telefon);
                        var mailId = Convert.ToInt16(IletisimTurleri.Mail);


                        var guncellenecekIletisim = aracDb.UyeIletisimleri
                            .Where(x => x.UyeId == bireyselUye.UyeId).ToList();


                        foreach (var item in guncellenecekIletisim)
                        {
                            if (item.IletisimId == telefonId)
                            {
                                item.IletisimBilgi = guncellenecekUyeBilgisi.Telefon;
                            }
                            else if (item.IletisimId == mailId)
                            {
                                item.IletisimBilgi = guncellenecekUyeBilgisi.Email;
                            }
                        }
                        aracDb.SaveChanges();
                    }
                    scope.Complete();
                    return new SuccessResult("Bireysel Üye güncellendi!");
                }
                catch (Exception ex)
                {

                    scope.Complete();
                    return new ErrorResult("Bireysel Üye güncellenemedi!");
                }
            }
        }

        public Result BireyselUyeSil(int? id)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    using (AracIhaleContext aracDb = new AracIhaleContext())
                    {

                        var silinecekUye = aracDb.Uyeler.Find(id);
                        if (silinecekUye != null)
                        {
                            silinecekUye.IsActive = false;
                            silinecekUye.IsDeleted = true;
                            silinecekUye.ModifiedDate = DateTime.Now;
                        }

                        var silinecekBireyselUye = aracDb.BireyselUyeler.SingleOrDefault(a => a.UyeId == id);
                        silinecekBireyselUye.IsActive = false;
                        silinecekBireyselUye.IsDeleted = true;

                        var telefonId = Convert.ToInt16(IletisimTurleri.Telefon);
                        var mailId = Convert.ToInt16(IletisimTurleri.Mail);

                        var guncellenecekIletisim = aracDb.UyeIletisimleri
                            .Where(x => x.UyeId == id).ToList();

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
