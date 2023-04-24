

namespace IkinciElAracIhaleSistemi.DAL.Migrations
{
	using IkinciElAracIhaleSistemi.Entities.Entities;
	using System;
	using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IkinciElAracIhaleSistemi.DAL.Context.AracIhaleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(IkinciElAracIhaleSistemi.DAL.Context.AracIhaleContext context)
        {
			context.Markalar.AddOrUpdate(
				new Marka { MarkaId = 1, MarkaAdi = "Ford" },
				new Marka { MarkaId = 2, MarkaAdi = "Toyota" },
				new Marka { MarkaId = 3, MarkaAdi = "Honda" },
				new Marka { MarkaId = 4, MarkaAdi = "BMW" },
				new Marka { MarkaId = 5, MarkaAdi = "Mercedes" },
				new Marka { MarkaId = 6, MarkaAdi = "Audi" },
				new Marka { MarkaId = 7, MarkaAdi = "Volkswagen" },
				new Marka { MarkaId = 8, MarkaAdi = "Renault" },
				new Marka { MarkaId = 9, MarkaAdi = "Nissan" },
				new Marka { MarkaId = 10, MarkaAdi = "Peugeot" }
				);


			context.Modeller.AddOrUpdate(
				new Model { ModelId = 1, ModelAdi = "Focus", MarkaId = 1, UstModelId = null },
				new Model { ModelId = 2, ModelAdi = "Fiesta", MarkaId = 1, UstModelId = null },
				new Model { ModelId = 3, ModelAdi = "Corolla", MarkaId = 2, UstModelId = null },
				new Model { ModelId = 4, ModelAdi = "Civic", MarkaId = 3, UstModelId = null },
				new Model { ModelId = 5, ModelAdi = "3 Serisi", MarkaId = 4, UstModelId = null },
				new Model { ModelId = 6, ModelAdi = "Clio", MarkaId = 8, UstModelId = null },
				new Model { ModelId = 7, ModelAdi = "Megane", MarkaId = 8, UstModelId = null },
				new Model { ModelId = 8, ModelAdi = "Astra", MarkaId = 7, UstModelId = null },
				new Model { ModelId = 9, ModelAdi = "Golf", MarkaId = 7, UstModelId = null },
				new Model { ModelId = 10, ModelAdi = "Qashqai", MarkaId = 9, UstModelId = null },
				new Model { ModelId = 11, ModelAdi = "Partner", MarkaId = 10, UstModelId = null },
				new Model { ModelId = 12, ModelAdi = "C 180", MarkaId = 5, UstModelId = null },
				new Model { ModelId = 13, ModelAdi = "A 180", MarkaId = 5, UstModelId = null },
				new Model { ModelId = 14, ModelAdi = "A4", MarkaId = 6, UstModelId = null }
				);

			context.Ozellikler.AddOrUpdate(
				new Ozellik { OzellikId = 1, OzellikAdi = "Gövde Tipi" },
				new Ozellik { OzellikId = 2, OzellikAdi = "Yakıt Tipi" },
				new Ozellik { OzellikId = 3, OzellikAdi = "Vites Tipi" },
				new Ozellik { OzellikId = 4, OzellikAdi = "Versiyon" },
				new Ozellik { OzellikId = 5, OzellikAdi = "Renk" },
				new Ozellik { OzellikId = 6, OzellikAdi = "Opsiyonel Donanım" }
			);

			context.OzellikDetaylari.AddOrUpdate(
				new OzellikDetay { OzellikDetayId = 1, OzellikId = 1, OzellikDetayi = "Sedan" },
				new OzellikDetay { OzellikDetayId = 2, OzellikId = 1, OzellikDetayi = "Hatchback" },
				new OzellikDetay { OzellikDetayId = 3, OzellikId = 1, OzellikDetayi = "Station Wagon" },
				new OzellikDetay { OzellikDetayId = 4, OzellikId = 1, OzellikDetayi = "Coupe" },
				new OzellikDetay { OzellikDetayId = 5, OzellikId = 2, OzellikDetayi = "Benzin" },
				new OzellikDetay { OzellikDetayId = 6, OzellikId = 2, OzellikDetayi = "Dizel" },
				new OzellikDetay { OzellikDetayId = 7, OzellikId = 2, OzellikDetayi = "Hibrit" },
				new OzellikDetay { OzellikDetayId = 8, OzellikId = 3, OzellikDetayi = "Manuel" },
				new OzellikDetay { OzellikDetayId = 9, OzellikId = 3, OzellikDetayi = "Otomatik" },
				new OzellikDetay { OzellikDetayId = 10, OzellikId = 4, OzellikDetayi = "Elegance" },
				new OzellikDetay { OzellikDetayId = 11, OzellikId = 4, OzellikDetayi = "Sport" },
				new OzellikDetay { OzellikDetayId = 12, OzellikId = 5, OzellikDetayi = "Beyaz" },
				new OzellikDetay { OzellikDetayId = 13, OzellikId = 5, OzellikDetayi = "Siyah" },
				new OzellikDetay { OzellikDetayId = 14, OzellikId = 5, OzellikDetayi = "Gri" },
				new OzellikDetay { OzellikDetayId = 15, OzellikId = 5, OzellikDetayi = "Mavi" },
				new OzellikDetay { OzellikDetayId = 16, OzellikId = 6, OzellikDetayi = "Navigasyon" },
				new OzellikDetay { OzellikDetayId = 17, OzellikId = 6, OzellikDetayi = "Bluetooth" },
				new OzellikDetay { OzellikDetayId = 18, OzellikId = 6, OzellikDetayi = "Park Sensörü" }
			);

			context.Araclar.AddOrUpdate(
				new Arac { Id = 1, Plaka = "06 ZIU 1998", MarkaId = 1, ModelId = 1, Km = 100000, Yil = 2015, KullaniciId = 1 },
				new Arac { Id = 2, Plaka = "06 ZU 1998",BireyselMi = true, MarkaId = 2, ModelId = 3, Km = 150000, Yil = 2017, KullaniciId = 1 },
				new Arac { Id = 3, Plaka = "06 IU 1998", BireyselMi = true, MarkaId = 3, ModelId = 4, Km = 116542, Yil = 2020, KullaniciId = 1 },
				new Arac { Id = 4, Plaka = "06 DU 1998", BireyselMi = true, MarkaId = 3, ModelId = 4, Km = 200000, Yil = 2014, KullaniciId = 1 },
				new Arac { Id = 5, Plaka = "06 MU 1998", BireyselMi = true, MarkaId = 4, ModelId = 5, Km = 300000, Yil = 2005, KullaniciId = 1 },
				new Arac { Id = 6, Plaka = "06 AU 1998", BireyselMi = false, MarkaId = 5, ModelId = 12, Km = 60000, Yil = 2021, KullaniciId = 1 },
				new Arac { Id = 7, Plaka = "06 RU 1998", BireyselMi = false, MarkaId = 5, ModelId = 13, Km = 90000, Yil = 2021, KullaniciId = 1 },
				new Arac { Id = 8, Plaka = "06 NU 1998", BireyselMi = false, MarkaId = 6, ModelId = 14, Km = 220000, Yil = 2015, KullaniciId = 1 },
				new Arac { Id = 9, Plaka = "06 BU 1998", BireyselMi = false, MarkaId = 7, ModelId = 8, Km = 240050, Yil = 2015, KullaniciId = 1 },
				new Arac { Id = 10, Plaka = "06 RU 1998", BireyselMi = true, MarkaId = 7, ModelId = 9, Km = 140000, Yil = 2019, KullaniciId = 1 },
				new Arac { Id = 11, Plaka = "06 GU 1998", BireyselMi = true, MarkaId = 8, ModelId = 6, Km = 280000, Yil = 2012, KullaniciId = 1 },
				new Arac { Id = 12, Plaka = "06 SU 1998", BireyselMi = true, MarkaId = 8, ModelId = 7, Km = 195000, Yil = 2017, KullaniciId = 1 },
				new Arac { Id = 13, Plaka = "06 GS 1998", BireyselMi = true, MarkaId = 9, ModelId = 10, Km = 32000, Yil = 2022, KullaniciId = 1 },
				new Arac { Id = 14, Plaka = "06 BJK 199", BireyselMi = true, MarkaId = 10, ModelId = 11, Km = 100000, Yil = 2015, KullaniciId = 1 }

				);

			context.AracOzellikleri.AddOrUpdate(
				new AracOzellik { Id = 1, AracId = 1, OzellikDetayId = 1 },
				new AracOzellik { Id = 2, AracId = 1, OzellikDetayId = 2 },
				new AracOzellik { Id = 3, AracId = 1, OzellikDetayId = 5 },
				new AracOzellik { Id = 4, AracId = 2, OzellikDetayId = 1 },
				new AracOzellik { Id = 5, AracId = 2, OzellikDetayId = 6 },
				new AracOzellik { Id = 6, AracId = 3, OzellikDetayId = 2 },
				new AracOzellik { Id = 7, AracId = 3, OzellikDetayId = 3 },
				new AracOzellik { Id = 8, AracId = 4, OzellikDetayId = 1 },
				new AracOzellik { Id = 9, AracId = 4, OzellikDetayId = 2 },
				new AracOzellik { Id = 10, AracId = 4, OzellikDetayId = 3 },
				new AracOzellik { Id = 11, AracId = 2, OzellikDetayId = 3 },
				new AracOzellik { Id = 12, AracId = 2, OzellikDetayId = 4 },
				new AracOzellik { Id = 13, AracId = 3, OzellikDetayId = 5 },
				new AracOzellik { Id = 14, AracId = 4, OzellikDetayId = 1 },
				new AracOzellik { Id = 15, AracId = 4, OzellikDetayId = 6 },
				new AracOzellik { Id = 16, AracId = 4, OzellikDetayId = 7 },
				new AracOzellik { Id = 17, AracId = 5, OzellikDetayId = 2 },
				new AracOzellik { Id = 18, AracId = 6, OzellikDetayId = 3 },
				new AracOzellik { Id = 19, AracId = 6, OzellikDetayId = 4 },
				new AracOzellik { Id = 20, AracId = 7, OzellikDetayId = 8 },
				new AracOzellik { Id = 21, AracId = 8, OzellikDetayId = 1 },
				new AracOzellik { Id = 22, AracId = 8, OzellikDetayId = 5 },
				new AracOzellik { Id = 23, AracId = 9, OzellikDetayId = 4 },
				new AracOzellik { Id = 24, AracId = 9, OzellikDetayId = 2 },
				new AracOzellik { Id = 25, AracId = 9, OzellikDetayId = 8 },
				new AracOzellik { Id = 26, AracId = 10, OzellikDetayId = 6 },
				new AracOzellik { Id = 27, AracId = 10, OzellikDetayId = 8 },
				new AracOzellik { Id = 28, AracId = 10, OzellikDetayId = 4 },
				new AracOzellik { Id = 29, AracId = 7, OzellikDetayId = 5 },
				new AracOzellik { Id = 30, AracId = 10, OzellikDetayId = 13 }

					);

			context.SaveChanges();
		}
    }
}
