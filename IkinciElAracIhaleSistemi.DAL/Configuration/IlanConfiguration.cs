
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class IlanConfiguration : EntityTypeConfiguration<Ilan>
	{
		public IlanConfiguration()
		{
			
			ToTable("Ilan");

			HasKey(i => i.Id);

			HasRequired(i => i.Arac)
				.WithMany()
				.HasForeignKey(i => i.AracId)
				.WillCascadeOnDelete(false);

			Property(i => i.Baslik)
				.HasMaxLength(100)
				.IsRequired();

			Property(i => i.Aciklama)
				.HasMaxLength(500)
				.IsRequired();

			Property(i => i.IsActive)
				.IsRequired();

			Property(i => i.IsDeleted)
				.IsRequired();
		}
	}

}
