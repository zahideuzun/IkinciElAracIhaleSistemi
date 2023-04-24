
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class SozlesmeTuruConfiguration : EntityTypeConfiguration<SozlesmeTuru>
	{
		public SozlesmeTuruConfiguration()
		{
			ToTable("SozlesmeTuru"); 

			HasKey(x => x.SozlesmeTuruId); 

			Property(x => x.SozlesmeTuruAdi)
				.IsRequired() 
				.HasMaxLength(50); 

			Property(x => x.IsActive).IsRequired(); 

			Property(x => x.IsDeleted).IsRequired();
		}
	}
}
