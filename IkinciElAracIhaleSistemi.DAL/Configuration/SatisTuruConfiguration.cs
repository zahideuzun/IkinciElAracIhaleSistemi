
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class SatisTuruConfiguration : EntityTypeConfiguration<SatisTuru>
	{
		public SatisTuruConfiguration()
		{
			ToTable("SatisTuru"); 

			HasKey(x => x.SatisTuruId); 

			Property(x => x.SatisTuruAdi)
				.IsRequired() 
				.HasMaxLength(50); 

			Property(x => x.IsActive).IsRequired(); 
			Property(x => x.IsDeleted).IsRequired(); 
		}
	}

}
