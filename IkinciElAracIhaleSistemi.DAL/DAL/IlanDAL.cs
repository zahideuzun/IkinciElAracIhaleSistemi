using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using IkinciElAracIhaleSistemi.App.Results;
using IkinciElAracIhaleSistemi.App.Results.Bases;
using IkinciElAracIhaleSistemi.DAL.Context;
using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemi.Entities.VM.Arac;

namespace IkinciElAracIhaleSistemi.DAL.DAL
{
	public class IlanDAL
	{
		public List<AracIlanVM> AktifIlanlariGetir()
		{
			using (AracIhaleContext aracDb = new AracIhaleContext())
			{
				return (from u in aracDb.Araclar
						join il in aracDb.Ilanlar on u.Id equals il.AracId
						where il.IsActive == true
						select new AracIlanVM()
						{
							AracId = il.AracId,
							Baslik = il.Baslik,
							IlanId = il.Id,
							AracMarka = u.Marka.MarkaAdi,
							AracModel = u.Model.ModelAdi,
							Aciklama = il.Aciklama,
							Tarih = il.Tarih.ToString()

						}).ToList();
			}
		}
		public Result IlanEkle(AracIlanVM ilan)
		{
			try
			{
				using (AracIhaleContext aracDb = new AracIhaleContext())
				{
					Ilan eklenenAracIlani = aracDb.Ilanlar.Add(new Ilan()
					{
						AracId = ilan.AracId,
						Baslik = ilan.Baslik,
						Aciklama = ilan.Aciklama,
						Tarih = DateTime.Now
					});
					aracDb.SaveChanges();
				}
				return new SuccessResult("Araç kaydedildi");
			}
			catch
			{
				return new ErrorResult("Araç kaydedilemedi!");
			}
			
		}
	}
}
