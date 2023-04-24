using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class UcretTipiConfiguration : EntityTypeConfiguration<UcretTipi>
	{
		public UcretTipiConfiguration()
		{
			ToTable("UcretTipi");
			HasKey(u => u.UcretTipiId);
			Property(ut => ut.UcretTipiAdi)
				.IsRequired()
				.HasMaxLength(60);

			Property(ut => ut.IsActive)
				.IsRequired();

			Property(ut => ut.IsDeleted)
				.IsRequired();

			HasMany(u => u.Ucretler)
				.WithRequired(ut => ut.UcretTipi)
				.HasForeignKey(ut => ut.UcretTipiId);
		}
	}

}
