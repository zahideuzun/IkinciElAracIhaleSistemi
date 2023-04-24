
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class FotografConfiguration : EntityTypeConfiguration<Fotograf>
	{
		public FotografConfiguration()
		{
			
			ToTable("Fotograf");

			HasKey(f => f.FotografId);

			HasRequired(f => f.Arac)
				.WithMany(a => a.Fotograf)
				.HasForeignKey(f => f.AracId)
				.WillCascadeOnDelete(false);

			Property(f => f.FotografYolu)
				.HasMaxLength(200)
				.IsRequired();

			Property(f => f.IsActive)
				.IsRequired();

			Property(f => f.IsDeleted)
				.IsRequired();
		}
	}

}
