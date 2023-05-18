using IkinciElAracIhaleSistemi.DAL.Configuration;
using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemi.Entities.Entities.Bases;
using System;
using System.Data.Entity;

namespace IkinciElAracIhaleSistemi.DAL.Context
{
	public class AracIhaleContext : DbContext 
	{
		public AracIhaleContext() : base("AracIhaleSistemiDB")
		{
			Configuration.LazyLoadingEnabled = false;
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//var service = PluralizationService.CreateService(new CultureInfo("en-US"));
			//modelBuilder.Entity<Arac>().ToTable(service.Pluralize(nameof(Arac)));

			#region Configuration

			modelBuilder.Configurations.Add(new AracConfiguration());
			modelBuilder.Configurations.Add(new AracFiyatConfiguration());
			modelBuilder.Configurations.Add(new AracIhaleConfiguration());
			modelBuilder.Configurations.Add(new AracOzellikConfiguration());
			modelBuilder.Configurations.Add(new AracParcaConfiguration());
			modelBuilder.Configurations.Add(new AracTeklifConfiguration());
			modelBuilder.Configurations.Add(new AracStatuConfiguration());
			modelBuilder.Configurations.Add(new AracTramerConfiguration());
			modelBuilder.Configurations.Add(new BireyselUyeConfiguration());
			modelBuilder.Configurations.Add(new BireyselUyeAracConfiguration());
			modelBuilder.Configurations.Add(new AracTramerDetayConfiguration());
			modelBuilder.Configurations.Add(new ChatbotConfiguration());
			modelBuilder.Configurations.Add(new EkspertizConfiguration());
			modelBuilder.Configurations.Add(new FavoriAramaConfiguration());
			modelBuilder.Configurations.Add(new FavoriAramaKriterConfiguration());
			modelBuilder.Configurations.Add(new FavoriIlanConfiguration());
			modelBuilder.Configurations.Add(new FavoriOzellikConfiguration());
			modelBuilder.Configurations.Add(new FirmaConfiguration());
			modelBuilder.Configurations.Add(new FirmaIletisimConfiguration());
			modelBuilder.Configurations.Add(new FirmaTuruConfiguration());
			modelBuilder.Configurations.Add(new FotografConfiguration());
			modelBuilder.Configurations.Add(new IhaleConfiguration());
			modelBuilder.Configurations.Add(new IhaleStatuConfiguration());
			modelBuilder.Configurations.Add(new IhaleTuruConfiguration());
			modelBuilder.Configurations.Add(new IlanConfiguration());
			modelBuilder.Configurations.Add(new IlceConfiguration());
			modelBuilder.Configurations.Add(new IletisimConfiguration());
			modelBuilder.Configurations.Add(new KullaniciConfiguration());
			modelBuilder.Configurations.Add(new KullaniciIletisimConfiguration());
			modelBuilder.Configurations.Add(new KurumsalUyeConfiguration());
			modelBuilder.Configurations.Add(new MarkaConfiguration());
			modelBuilder.Configurations.Add(new MesajConfiguration());
			modelBuilder.Configurations.Add(new ModelConfiguration());
			modelBuilder.Configurations.Add(new OzellikConfiguration());
			modelBuilder.Configurations.Add(new OzellikDetayConfiguration());
			modelBuilder.Configurations.Add(new PaketConfiguration());
			modelBuilder.Configurations.Add(new RolConfiguration());
			modelBuilder.Configurations.Add(new RolYetkiConfiguration());
			modelBuilder.Configurations.Add(new SatisConfiguration());
			modelBuilder.Configurations.Add(new SatisTuruConfiguration());
			modelBuilder.Configurations.Add(new SayfaConfiguration());
			modelBuilder.Configurations.Add(new SehirConfiguration());
			modelBuilder.Configurations.Add(new SehirIlceConfiguration());
			modelBuilder.Configurations.Add(new SozlesmeConfiguration());
			modelBuilder.Configurations.Add(new SozlesmeTuruConfiguration());
			modelBuilder.Configurations.Add(new StatuConfiguration());
			modelBuilder.Configurations.Add(new StokConfiguration());
			modelBuilder.Configurations.Add(new TramerConfiguration());
			modelBuilder.Configurations.Add(new UcretConfiguration());
			modelBuilder.Configurations.Add(new UyeConfiguration());
			modelBuilder.Configurations.Add(new UyeTuruConfiguration());
			modelBuilder.Configurations.Add(new UcretTipiConfiguration());
			modelBuilder.Configurations.Add(new UyeIletisimConfiguration());

			#endregion

			base.OnModelCreating(modelBuilder);
		}



		#region DbSet

		public DbSet<Arac> Araclar { get; set; }
		public DbSet<AracStatu> AracStatu { get; set; }
		public DbSet<AracTeklif> AracTeklifleri { get; set; }
		public DbSet<AracOzellik> AracOzellikleri { get; set; }
		public DbSet<AracParca> AracParcalari { get; set; }
		public DbSet<AracIhale> AracIhaleleri { get; set; }
		public DbSet<AracTramerDetay> AracTramerDetaylari { get; set; }
		public DbSet<AracTramer> AracTramerleri { get; set; }
		public DbSet<BireyselUye> BireyselUyeler { get; set; }
		public DbSet<BireyselUyeArac> BireyselUyeAraclar { get; set; }
		public DbSet<AracFiyat> AracFiyatlari { get; set; }
		public DbSet<Ihale> Ihaleler { get; set; }
		public DbSet<IhaleStatu> IhaleStatuleri { get; set; }
		public DbSet<Firma> Firmalar { get; set; }
		public DbSet<FirmaTuru> FirmaTurleri { get; set; }
		public DbSet<FirmaIletisim> FirmaIletisimleri { get; set; }
		public DbSet<IhaleTuru> IhaleTurleri { get; set; }
		public DbSet<Ekspertiz> Ekspertizler { get; set; }
		public DbSet<Marka> Markalar { get; set; }
		public DbSet<Model> Modeller { get; set; }
		public DbSet<Ozellik> Ozellikler { get; set; }
		public DbSet<OzellikDetay> OzellikDetaylari { get; set; }
		public DbSet<Sehir> Sehirler { get; set; }
		public DbSet<Ilce> Ilceler { get; set; }
		public DbSet<Ilan> Ilanlar { get; set; }
		public DbSet<SehirIlce> SehirIlceleri { get; set; }
		public DbSet<KurumsalUye> KurumsalUyeler { get; set; }
		public DbSet<Uye> Uyeler { get; set; }
		public DbSet<UyeIletisim> UyeIletisimleri { get; set; }
		public DbSet<UyeTuru> UyeTurleri { get; set; }
		public DbSet<Mesaj> Mesajlar { get; set; }
		public DbSet<Paket> Paketler { get; set; }
		public DbSet<Kullanici> Kullanicilar { get; set; }
		public DbSet<KullaniciIletisim> KullaniciIletisimleri { get; set; }
		public DbSet<Fotograf> Fotograflar { get; set; }
		public DbSet<Sozlesme> Sozlesmeler { get; set; }
		public DbSet<SozlesmeTuru> SozlesmeTurleri { get; set; }
		public DbSet<Rol> Roller { get; set; }
		public DbSet<Sayfa> Sayfalar { get; set; }
		public DbSet<RolYetki> RolYetkileri { get; set; }
		public DbSet<UcretTipi> UcretTipleri { get; set; }
		public DbSet<Ucret> Ucretler { get; set; }
		public DbSet<SatisTuru> SatisTurleri { get; set; }
		public DbSet<Satis> Satislar { get; set; }
		public DbSet<Stok> Stoklar { get; set; }
		public DbSet<Tramer> Tramerler { get; set; }
		public DbSet<Iletisim> Iletisimler { get; set; }
		public DbSet<Chatbot> Chatbotlar { get; set; }
		public DbSet<Statu> Status { get; set; }

		#endregion

		public override int SaveChanges()
		{
			var data = ChangeTracker.Entries<BaseEntity>();
			foreach (var entry in data)
			{
				if (entry.State == EntityState.Added)
				{
					entry.Entity.CreatedDate = DateTime.Now;
					entry.Entity.IsActive = true;
					entry.Entity.IsDeleted = false;
				}
				else if (entry.State == EntityState.Modified)
				{
					entry.Entity.ModifiedDate = DateTime.Now;
				}
				else if (entry.State == EntityState.Deleted)
				{
					entry.Entity.ModifiedDate = DateTime.Now;
					entry.Entity.IsActive = false;
					entry.Entity.IsDeleted = true;
					entry.State = EntityState.Modified;
				}
			}
			return base.SaveChanges();
		}
	}
}
