
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class TramerConfiguration : EntityTypeConfiguration<Tramer>
	{
		public TramerConfiguration()
		{
			HasKey(t => t.TramerId);
			Property(t => t.TramerAdi)
				.IsRequired()
				.HasMaxLength(50);
			ToTable("Tramer");
		}
	}

}
