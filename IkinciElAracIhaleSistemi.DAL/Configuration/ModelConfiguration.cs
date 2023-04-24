using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class ModelConfiguration : EntityTypeConfiguration<Model>
	{
		public ModelConfiguration()
		{
			ToTable("Model");

			Property(m => m.ModelAdi)
				.IsRequired()
				.HasMaxLength(50);

			HasMany(m => m.Arac)
				.WithRequired(a => a.Model)
				.HasForeignKey(a => a.ModelId)
				.WillCascadeOnDelete(false);

			HasMany(m => m.FavoriAramaKriter)
				.WithRequired(f => f.Model)
				.HasForeignKey(f => f.ModelId)
				.WillCascadeOnDelete(false);
		}
	}
}
