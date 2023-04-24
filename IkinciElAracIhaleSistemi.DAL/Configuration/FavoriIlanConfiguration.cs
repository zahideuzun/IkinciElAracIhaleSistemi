using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class FavoriIlanConfiguration : EntityTypeConfiguration<FavoriIlan>
	{
		public FavoriIlanConfiguration()
		{
			
			ToTable("FavoriIlan");

			HasKey(fi => fi.FavoriIlanId);

			HasRequired(fi => fi.Ilan)
				.WithMany()
				.HasForeignKey(fi => fi.IlanId)
				.WillCascadeOnDelete(false);

			HasRequired(fi => fi.Uye)
				.WithMany()
				.HasForeignKey(fi => fi.UyeId)
				.WillCascadeOnDelete(false);

			Property(fi => fi.Tarih)
				.IsRequired();

			Property(fi => fi.IsActive)
				.IsRequired();

			Property(fi => fi.IsDeleted)
				.IsRequired();
		}
	}
}
