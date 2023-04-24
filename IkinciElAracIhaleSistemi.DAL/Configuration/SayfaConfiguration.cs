using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class SayfaConfiguration : EntityTypeConfiguration<Sayfa>
	{
		public SayfaConfiguration()
		{
			ToTable("Sayfa");
			Property(x => x.SayfaAdi).HasMaxLength(100);
			Property(x => x.SayfaLink).HasMaxLength(200);
		}
	}
}
