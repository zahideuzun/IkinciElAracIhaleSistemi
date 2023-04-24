
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class IhaleConfiguration : EntityTypeConfiguration<Ihale>
	{
		public IhaleConfiguration()
		{
		
			ToTable("Ihale");

			HasKey(i => i.Id);

			Property(i => i.IhaleAdi)
				.HasMaxLength(50)
				.IsRequired();

			HasRequired(i => i.Kullanici)
				.WithMany(k => k.Ihaleler)
				.HasForeignKey(i => i.KullaniciId)
				.WillCascadeOnDelete(false);

			HasMany(i => i.AracIhale)
				.WithRequired(ai => ai.Ihale)
				.HasForeignKey(ai => ai.IhaleId);

			HasMany(i => i.IhaleStatu)
				.WithRequired( ist => ist.Ihale)
				.HasForeignKey( ist => ist.IhaleId);
		}
	}
}
