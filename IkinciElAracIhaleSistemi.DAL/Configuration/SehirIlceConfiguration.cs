
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class SehirIlceConfiguration : EntityTypeConfiguration<SehirIlce>
	{
		public SehirIlceConfiguration()
		{
			ToTable("SehirIlce");

			HasKey(x => x.SehirIlceId);

			HasRequired(x => x.Sehir)
				.WithMany(x => x.SehirIlceleri)
				.HasForeignKey(x => x.SehirId)
				.WillCascadeOnDelete(false);

			HasRequired(x => x.Ilce)
				.WithMany(x => x.SehirIlceleri)
				.HasForeignKey(x => x.IlceId)
				.WillCascadeOnDelete(false);

		}
	}
}
