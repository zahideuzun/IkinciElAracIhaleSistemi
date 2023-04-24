using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class UyeTuruConfiguration : EntityTypeConfiguration<UyeTuru>
	{
		public UyeTuruConfiguration()
		{
			ToTable("UyeTuru");
			HasKey(x => x.UyeTuruId);
			Property(x => x.UyeTuruAdi).IsRequired().HasMaxLength(50);
			HasMany(x => x.Uye).WithRequired(x => x.UyeTuru).HasForeignKey(x => x.UyeTuruId);
		}
	}
}
