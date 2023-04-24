
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class OzellikDetayConfiguration : EntityTypeConfiguration<OzellikDetay>
	{
		public OzellikDetayConfiguration()
		{
			ToTable("OzellikDetay");

			HasKey(od => od.OzellikDetayId);

			Property(od => od.OzellikDetayi)
				.IsRequired()
				.HasMaxLength(50);

			Property(od => od.IsActive)
				.IsRequired();

			Property(od => od.IsDeleted)
				.IsRequired();

			HasRequired(od => od.Ozellik)
				.WithMany(o => o.OzellikDetay)
				.HasForeignKey(od => od.OzellikId);
		}
	}

}
