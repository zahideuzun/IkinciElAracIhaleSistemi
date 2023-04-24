using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class FirmaIletisimConfiguration : EntityTypeConfiguration<FirmaIletisim>
	{
		public FirmaIletisimConfiguration()
		{
			ToTable("FirmaIletisim");
			HasKey(x => x.Id);

			Property(x => x.IletisimBilgi)
				.HasMaxLength(200)
				.IsRequired();

			HasRequired(x => x.Firma)
				.WithMany(x => x.FirmaIletisimler)
				.HasForeignKey(x => x.FirmaId)
				.WillCascadeOnDelete(false);

			HasRequired(x => x.Iletisim)
				.WithMany()
				.HasForeignKey(x => x.IletisimId);

			Property(x => x.IsActive)
				.IsRequired();

			Property(x => x.IsDeleted)
				.IsRequired();
		}
	}

}
