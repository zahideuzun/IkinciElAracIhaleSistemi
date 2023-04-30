using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class AracConfiguration : EntityTypeConfiguration<Arac>
	{
		public AracConfiguration()
		{
			ToTable("Arac");

			HasKey(a => a.Id);

			Property(a => a.Yil)
				.IsRequired();

			Property(a => a.Plaka)
				.IsRequired()
				.HasMaxLength(15);

			Property(a => a.Km)
				.IsRequired();

			Property(a => a.BireyselMi)
				.IsRequired();

			Property(a => a.Aciklama)
				.IsOptional();

			HasRequired(a => a.Kullanici)
				.WithMany(k => k.Araclar)
				.HasForeignKey(a => a.KullaniciId);

			HasRequired(a => a.Uye)
				.WithMany(k => k.Araclar)
				.HasForeignKey(a => a.UyeId);

			HasRequired(a => a.Marka)
				.WithMany(m => m.Arac)
				.HasForeignKey(a => a.MarkaId);

			HasRequired(a => a.Model)
				.WithMany(m => m.Arac)
				.HasForeignKey(a => a.ModelId);

			HasMany(a => a.AracFiyat)
				.WithRequired(af => af.Arac)
				.HasForeignKey(af => af.AracId);

			HasMany(a => a.AracOzellik)
				.WithRequired(ao => ao.Arac)
				.HasForeignKey(ao => ao.AracId);

			HasMany(a => a.AracStatu)
				.WithRequired(a => a.Arac)
				.HasForeignKey(a => a.AracId);

			HasMany(a => a.AracTramer)
				.WithRequired(at => at.Arac)
				.HasForeignKey(at => at.AracId);

			HasMany(a => a.Fotograf)
				.WithRequired(f => f.Arac)
				.HasForeignKey(f => f.AracId);

			HasMany(a => a.AracIhale)
				.WithRequired(ai => ai.Arac)
				.HasForeignKey(ai => ai.AracId);

			HasMany(a => a.Ilan)
				.WithRequired(i => i.Arac)
				.HasForeignKey(i => i.AracId);
		}
	}

}
