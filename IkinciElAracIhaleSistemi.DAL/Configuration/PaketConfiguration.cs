using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class PaketConfiguration : EntityTypeConfiguration<Paket>
	{
		public PaketConfiguration()
		{
			ToTable("Paket"); 

			HasKey(x => x.PaketId);

			Property(x => x.Ad)
				.IsRequired() 
				.HasMaxLength(50); 

			Property(x => x.AracLimiti).IsRequired(); 

			HasMany(x => x.Firma)
				.WithMany()
				.Map(x =>
				{
					x.MapLeftKey("PaketId");
					x.MapRightKey("FirmaId");
					x.ToTable("PaketFirma");
				});

			Property(x => x.IsActive).IsRequired();
			Property(x => x.IsDeleted).IsRequired(); 
		}
	}

}
