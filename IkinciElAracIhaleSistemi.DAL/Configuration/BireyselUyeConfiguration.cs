using IkinciElAracIhaleSistemi.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class BireyselUyeConfiguration : EntityTypeConfiguration<BireyselUye>
	{
		public BireyselUyeConfiguration()
		{
			ToTable("BireyselUye");
			HasKey(u => u.Id);

			Property(u => u.TcKimlikNo)
				.IsRequired()
				.HasMaxLength(11);

			HasRequired(u => u.Uye)
				.WithMany()
				.HasForeignKey(u => u.UyeId);
			
			HasRequired(bu => bu.Rol)
				.WithMany(r => r.BireyselUyeler)
				.HasForeignKey(bu => bu.RolId);

			HasRequired(k => k.Rol)
				.WithMany()
				.HasForeignKey(k => k.RolId);

		}
	}


}
