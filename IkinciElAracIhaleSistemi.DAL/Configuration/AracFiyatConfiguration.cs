
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class AracFiyatConfiguration : EntityTypeConfiguration<AracFiyat>
	{
		public AracFiyatConfiguration()
		{
			ToTable("AracFiyat");

			HasKey(af => af.Id);

			Property(af => af.Fiyat)
				.IsRequired();

			Property(af => af.Tarih)
				.IsRequired();

			HasRequired(af => af.Arac)
				.WithMany(a => a.AracFiyat)
				.HasForeignKey(af => af.AracId);
		}
	}

}
