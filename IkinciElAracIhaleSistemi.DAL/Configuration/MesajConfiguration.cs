using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class MesajConfiguration : EntityTypeConfiguration<Mesaj>
	{
		public MesajConfiguration()
		{
			ToTable("Mesaj");

			HasKey(m => m.MesajId); 

			Property(m => m.MesajBilgisi)
				.IsRequired();


		}
	}

}
