using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IkinciElAracIhaleSistemi.Entities.VM
{
    public class IhaleVM
    {
        public int IhaleId { get; set; }
        public string IhaleAdi { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public TimeSpan BaslangicSaati { get; set; }
        public TimeSpan BitisSaati { get; set; }
        public string Statu { get; set; }
        public string IhaleTuru { get; set; }
        public int OlusturanKullaniciId { get; set; }
        public string OlusturanKullanici { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public int IhaleTuruId { get; set; }
        public List<SelectListItem> IhaleTurleri { get; set; }
        public List<SelectListItem> Statuler { get; set; }
        public List<SelectListItem> IdyeGoreFirmalar { get; set; }
    }
}
