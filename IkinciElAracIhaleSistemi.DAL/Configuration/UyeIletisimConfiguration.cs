using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class UyeIletisimConfiguration : EntityTypeConfiguration<UyeIletisim>
	{
		public UyeIletisimConfiguration()
		{
			ToTable("UyeIletisim");
			Property(x => x.IletisimBilgi).IsRequired().HasMaxLength(100);
			HasRequired(x => x.Uye).WithMany(x => x.UyeIletisim).HasForeignKey(x => x.UyeId);
			HasRequired(x => x.Iletisim).WithMany().HasForeignKey(x => x.IletisimId);
		}
	}
}
