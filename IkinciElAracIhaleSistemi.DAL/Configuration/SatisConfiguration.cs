
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class SatisConfiguration : EntityTypeConfiguration<Satis>
	{
		public SatisConfiguration()
		{
			ToTable("Satis");

			HasKey(s => s.Id);

			HasRequired(s => s.SatisTuru)
				.WithMany()
				.HasForeignKey(s => s.SatisTuruId);

			HasRequired(s => s.Ucret)
				.WithMany()
				.HasForeignKey(s => s.UcretId);

			HasRequired(s => s.Uye)
				.WithMany(u => u.AldigiAraclar)
				.HasForeignKey(s => s.UyeId);

			HasRequired(s => s.Uye)
				.WithMany()
				.HasForeignKey(s => s.UyeId);
		}
	}

}
