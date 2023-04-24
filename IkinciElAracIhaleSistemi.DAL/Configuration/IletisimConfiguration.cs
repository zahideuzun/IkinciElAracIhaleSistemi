using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class IletisimConfiguration : EntityTypeConfiguration<Iletisim>
	{
		public IletisimConfiguration()
		{
			ToTable("Iletisim");
			HasKey(i => i.IletisimId);

			Property(i => i.IletisimAdi)
				.IsRequired()
				.HasMaxLength(50);

			HasMany(i => i.UyeIletisim)
				.WithRequired(ui => ui.Iletisim)
				.HasForeignKey(ui => ui.IletisimId);

			HasMany(i => i.FirmaIletisim)
				.WithRequired(fi => fi.Iletisim)
				.HasForeignKey(fi => fi.IletisimId);

			HasMany(i => i.KullaniciIletisim)
				.WithRequired(ki => ki.Iletisim)
				.HasForeignKey(ki => ki.IletisimId);

			Property(i => i.IsActive)
				.IsRequired();

			Property(i => i.IsDeleted)
				.IsRequired();
		}
	}

}
