
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class StokConfiguration : EntityTypeConfiguration<Stok>
	{
		public StokConfiguration()
		{
			ToTable("Stok"); 

			HasKey(x => x.Id); 

			Property(x => x.FirmaId).IsRequired(); 
			Property(x => x.AracId).IsRequired(); 
			Property(x => x.Tarih).IsRequired(); 

			HasRequired(x => x.Firma)
				.WithMany()
				.HasForeignKey(x => x.FirmaId)
				.WillCascadeOnDelete(false);
			
			HasRequired(x => x.Arac)
				.WithMany()
				.HasForeignKey(x => x.AracId)
				.WillCascadeOnDelete(false);
		}
	}

}
