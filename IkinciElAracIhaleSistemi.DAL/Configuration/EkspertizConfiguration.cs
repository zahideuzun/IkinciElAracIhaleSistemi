using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class EkspertizConfiguration : EntityTypeConfiguration<Ekspertiz>
	{
		public EkspertizConfiguration()
		{
			
			ToTable("Ekspertiz");

			HasKey(e => e.EkspertizId);

			Property(e => e.Ad)
				.IsRequired()
				.HasMaxLength(100);

			Property(e => e.Adres)
				.IsRequired()
				.HasMaxLength(250);

		}
	}

}
