using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class RolYetkiConfiguration : EntityTypeConfiguration<RolYetki>
	{
		public RolYetkiConfiguration()
		{
			ToTable("RolYetki");
			HasKey(x => new { x.RolId, x.SayfaId });

			HasRequired(x => x.Rol)
				.WithMany(x => x.RolYetkileri)
				.HasForeignKey(x => x.RolId);

			HasRequired(x => x.Sayfa)
				.WithMany(x => x.SayfaRolYetkileri)
				.HasForeignKey(x => x.SayfaId);
		}
	}
}
