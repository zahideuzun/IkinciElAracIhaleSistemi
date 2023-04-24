
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class UyeConfiguration : EntityTypeConfiguration<Uye>
	{
		public UyeConfiguration()
		{
			ToTable("Uye");

			HasKey(u => u.Id);

			Property(u => u.Isim)
				.HasMaxLength(80)
				.IsRequired();

			Property(u => u.Soyisim)
				.HasMaxLength(80)
				.IsRequired();

			Property(u => u.Email)
				.HasMaxLength(100)
				.IsRequired();

			Property(u => u.Telefon)
				.HasMaxLength(20)
				.IsRequired();

			Property(u => u.Sifre)
				.HasMaxLength(20)
				.IsRequired();

			HasRequired(u => u.UyeTuru)
				.WithMany()
				.HasForeignKey(u => u.UyeTuruId);

			HasMany(u => u.UyeIletisim)
				.WithRequired(ui => ui.Uye)
				.HasForeignKey(ui => ui.UyeId);

			HasMany(u => u.AracTeklif)
				.WithRequired(at => at.Uye)
				.HasForeignKey(at => at.UyeId);

			HasMany(u => u.FavoriArama)
				.WithRequired(fa => fa.Uye)
				.HasForeignKey(fa => fa.UyeId);

			HasMany(u => u.FavoriIlan)
				.WithRequired(fi => fi.Uye)
				.HasForeignKey(fi => fi.UyeId);

			HasMany(u => u.AldigiAraclar)
				.WithRequired(s => s.Uye)
				.HasForeignKey(s => s.UyeId);
		}
	}

}
