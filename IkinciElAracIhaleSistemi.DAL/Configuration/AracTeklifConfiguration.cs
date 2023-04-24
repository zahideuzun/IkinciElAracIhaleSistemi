using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class AracTeklifConfiguration : EntityTypeConfiguration<AracTeklif>
	{
		public AracTeklifConfiguration()
		{
			ToTable("AracTeklif");

			HasKey(at => at.Id);

			Property(at => at.AracIhaleId).IsRequired();
			Property(at => at.UyeId).IsRequired();
			Property(at => at.TeklifEdilenFiyat).IsRequired().HasPrecision(18, 2);
			Property(at => at.TeklifTarihi).IsRequired();
			Property(at => at.OnaylandiMi).IsRequired();

			HasRequired(at => at.Uye)
				.WithMany()
				.HasForeignKey(at => at.UyeId)
				.WillCascadeOnDelete(false);

			HasRequired(at => at.AracIhale)
				.WithMany(ai => ai.AracTeklifler)
				.HasForeignKey(at => at.AracIhaleId)
				.WillCascadeOnDelete(false);
		}
	}

}


