using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class MarkaConfiguration : EntityTypeConfiguration<Marka>
	{
		public MarkaConfiguration()
		{
			ToTable("Marka");
			Property(m => m.MarkaAdi)
				.IsRequired()
				.HasMaxLength(50);

			HasMany(m => m.Arac)
				.WithRequired(a => a.Marka)
				.HasForeignKey(a => a.MarkaId)
				.WillCascadeOnDelete(false);

			HasMany(m => m.FavoriAramaKriter)
				.WithRequired(f => f.Marka)
				.HasForeignKey(f => f.MarkaId)
				.WillCascadeOnDelete(false);
		}
	}
}
