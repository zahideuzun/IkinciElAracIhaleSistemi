
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

			Property(s => s.IlanId)
				.IsRequired();

			Property(s => s.SatisTarihi)
				.IsRequired();

			Property(s => s.SatisToplamUcreti)
				.IsRequired();

			Property(s => s.UcretId)
				.IsRequired();

			Property(s => s.BireyselUyeAracId)
				.IsRequired();

			Property(s => s.SatisTuruId)
				.IsRequired();

			HasRequired(s => s.SatisTuru)
				.WithMany()
				.HasForeignKey(s => s.SatisTuruId)
				.WillCascadeOnDelete(false);

			HasRequired(s => s.Ucret)
				.WithMany()
				.HasForeignKey(s => s.UcretId)
				.WillCascadeOnDelete(false);

			HasRequired(s => s.BireyselUyeArac)
				.WithMany(bua => bua.AldigiAraclar)
				.HasForeignKey(s => s.BireyselUyeAracId)
				.WillCascadeOnDelete(false);

		}
	}


}
