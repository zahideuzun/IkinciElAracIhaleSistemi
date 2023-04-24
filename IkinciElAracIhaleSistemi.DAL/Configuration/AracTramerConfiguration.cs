using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class AracTramerConfiguration : EntityTypeConfiguration<AracTramer>
	{
		public AracTramerConfiguration()
		{
			
			HasKey(t => t.AracTramerId);

			Property(t => t.AracId)
				.IsRequired();

			Property(t => t.TramerFiyati)
				.IsRequired();

			HasRequired(t => t.Arac)
				.WithMany()
				.HasForeignKey(t => t.AracId)
				.WillCascadeOnDelete(false);

			HasMany(t => t.AracTramerDetaylari)
				.WithRequired(t => t.AracTramer)
				.HasForeignKey(t => t.AracTramerId)
				.WillCascadeOnDelete(false);

			ToTable("AracTramer");
		}
	}

}
