using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class IlceConfiguration : EntityTypeConfiguration<Ilce>
	{
		public IlceConfiguration()
		{
			ToTable("Ilce");

			HasKey(x => x.IlceId);

			Property(x => x.IlceAdi)
				.IsRequired()
				.HasMaxLength(50);

			HasMany(x => x.SehirIlceleri)
				.WithRequired(x => x.Ilce)
				.HasForeignKey(x => x.IlceId);
		}
	}
}
