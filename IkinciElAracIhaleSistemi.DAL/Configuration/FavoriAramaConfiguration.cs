using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class FavoriAramaConfiguration : EntityTypeConfiguration<FavoriArama>
	{
		public FavoriAramaConfiguration()
		{
			
			ToTable("FavoriArama");

			HasKey(fa => fa.FavoriAramaId);

			HasRequired(fa => fa.FavoriAramaKriter)
				.WithMany(fak => fak.FavoriAramalar)
				.HasForeignKey(fa => fa.FavoriAramaKriterId)
				.WillCascadeOnDelete(false);

			HasRequired(fa => fa.Uye)
				.WithMany()
				.HasForeignKey(fa => fa.UyeId)
				.WillCascadeOnDelete(false);

			// Set column properties
			Property(fa => fa.AramaAdi)
				.IsRequired()
				.HasMaxLength(50);

			Property(fa => fa.IsActive)
				.IsRequired();

			Property(fa => fa.IsDeleted)
				.IsRequired();
		}
	}
}
