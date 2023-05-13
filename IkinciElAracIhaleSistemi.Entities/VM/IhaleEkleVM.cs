using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IkinciElAracIhaleSistemi.Entities.VM
{
    public class IhaleEkleVM
    {
        public int IhaleId { get; set; }
        public string IhaleAdi { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public TimeSpan BaslangicSaati { get; set; }
        public TimeSpan BitisSaati { get; set; }
        public string Statu { get; set; }
        public int StatuId { get; set; }
        public string IhaleTuru { get; set; }
        public int IhaleTuruId { get; set; }
        public int BireyselVeyaFirmaId { get; set; }
        public int OlusturanKullaniciId { get; set; }
        public string OlusturanKullanici { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public int AracId { get; set; }
        public decimal IhaleBaslangicFiyati { get; set; }
        public decimal MinimumAlimFiyati { get; set; }
        public List<SelectListItem> IdyeGoreFirmalar { get; set; }
    }
}
