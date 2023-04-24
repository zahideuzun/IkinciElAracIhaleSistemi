
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class SehirConfiguration : EntityTypeConfiguration<Sehir>
	{
		public SehirConfiguration()
		{
			ToTable("Sehir");

			HasKey(x => x.SehirId);

			Property(x => x.SehirAdi)
				.IsRequired()
				.HasMaxLength(50);

			HasMany(x => x.SehirIlceleri)
				.WithRequired(x => x.Sehir)
				.HasForeignKey(x => x.SehirId);
		}
	}
}
