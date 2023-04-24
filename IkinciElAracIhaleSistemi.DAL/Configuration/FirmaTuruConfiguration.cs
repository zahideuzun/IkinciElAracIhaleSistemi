using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class FirmaTuruConfiguration : EntityTypeConfiguration<FirmaTuru>
	{
		public FirmaTuruConfiguration()
		{
			ToTable("FirmaTuru");
			HasKey(x => x.FirmaTuruId);

			Property(x => x.FirmaTuruAdi)
				.HasMaxLength(100)
				.IsRequired();

			HasMany(x => x.Firmalar)
				.WithRequired(x => x.FirmaTuru)
				.HasForeignKey(x => x.FirmaTuruId);

			Property(x => x.IsActive)
				.IsRequired();

			Property(x => x.IsDeleted)
				.IsRequired();
		}
	}

}
