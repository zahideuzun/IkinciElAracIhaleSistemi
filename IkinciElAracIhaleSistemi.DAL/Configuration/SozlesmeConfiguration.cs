
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class SozlesmeConfiguration : EntityTypeConfiguration<Sozlesme>
	{
		public SozlesmeConfiguration()
		{
			ToTable("Sozlesme"); 

			HasKey(x => x.SozlesmeId); 

			Property(x => x.SozlesmePath).IsRequired(); 
			Property(x => x.SozlesmeTarih).IsRequired(); 

			HasRequired(x => x.SozlesmeTuru) 
				.WithMany()
				.HasForeignKey(x => x.SozlesmeTuruId)
				.WillCascadeOnDelete(false);

			Property(x => x.IsActive).IsRequired(); 

			Property(x => x.IsDeleted).IsRequired(); 
		}
	}
}
