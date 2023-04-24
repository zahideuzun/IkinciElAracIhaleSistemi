
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class FavoriAramaKriterConfiguration : EntityTypeConfiguration<FavoriAramaKriter>
	{
		public FavoriAramaKriterConfiguration()
		{
			
			ToTable("FavoriAramaKriter");

			HasKey(fak => fak.FavoriAramaKriterId);

			HasRequired(fak => fak.Marka)
				.WithMany()
				.HasForeignKey(fak => fak.MarkaId)
				.WillCascadeOnDelete(false);

			
			HasRequired(fak => fak.Model)
				.WithMany()
				.HasForeignKey(fak => fak.ModelId)
				.WillCascadeOnDelete(false);

			Property(fak => fak.BaslangicYili)
				.IsRequired();

			Property(fak => fak.BitisYili)
				.IsRequired();

			Property(fak => fak.BaslangicFiyati)
				.IsRequired();

			Property(fak => fak.BitisFiyati)
				.IsRequired();

			Property(fak => fak.BaslangicKm)
				.IsRequired();

			Property(fak => fak.BitisKm)
				.IsRequired();

			Property(fak => fak.IsActive)
				.IsRequired();

			Property(fak => fak.IsDeleted)
				.IsRequired();
		}
	}
}
