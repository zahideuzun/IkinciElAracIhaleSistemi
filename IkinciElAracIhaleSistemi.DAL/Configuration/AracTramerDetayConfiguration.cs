
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class AracTramerDetayConfiguration : EntityTypeConfiguration<AracTramerDetay>
	{
		public AracTramerDetayConfiguration()
		{
			
			HasKey(t => t.AracTramerDetayId);

			Property(t => t.AracParcaId)
				.IsRequired();

			Property(t => t.TramerId)
				.IsRequired();

			HasRequired(t => t.Tramer)
				.WithMany()
				.HasForeignKey(t => t.TramerId)
				.WillCascadeOnDelete(false);
			
			HasRequired(t => t.AracParca)
				.WithMany()
				.HasForeignKey(t => t.AracParcaId)
				.WillCascadeOnDelete(false);

			HasRequired(t => t.AracTramer)
				.WithMany(t => t.AracTramerDetaylari)
				.HasForeignKey(t => t.AracTramerId)
				.WillCascadeOnDelete(false);

			ToTable("AracTramerDetay");
		}
	}
}
