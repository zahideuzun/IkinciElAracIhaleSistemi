
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class AracOzellikConfiguration : EntityTypeConfiguration<AracOzellik>
	{
		public AracOzellikConfiguration()
		{
			ToTable("AracOzellik");

			HasKey(ao => ao.Id);

			HasRequired(ao => ao.Arac)
				.WithMany(a => a.AracOzellik)
				.HasForeignKey(ao => ao.AracId);

			HasRequired(ao => ao.OzellikDetay)
				.WithMany(od => od.AracOzellikleri)
				.HasForeignKey(ao => ao.OzellikDetayId);
		}
	}

}
