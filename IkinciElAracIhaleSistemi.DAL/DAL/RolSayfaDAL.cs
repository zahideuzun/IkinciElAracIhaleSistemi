using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.DAL.Context;
using IkinciElAracIhaleSistemi.Entities.VM;

namespace IkinciElAracIhaleSistemi.DAL.DAL
{
	public class RolSayfaDAL
	{
		public List<RolSayfaVM> RoleGoreSayfaYetkileriniGetir(int kullaniciRol)
		{
			List < RolSayfaVM > sayfaListesi = null;
			using (AracIhaleContext aracDb = new AracIhaleContext())
			{
				sayfaListesi = (from s in aracDb.RolYetkileri
						join sy in aracDb.Sayfalar on s.SayfaId equals sy.SayfaId
						where s.RolId == kullaniciRol
						select new RolSayfaVM()
						{
							SayfaId = sy.SayfaId,
							SayfaIsim = sy.SayfaAdi,
							SayfaLink = sy.SayfaLink
						}
					).ToList();
			}
			return sayfaListesi;
		}
	}
}
