using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class UcretConfiguration : EntityTypeConfiguration<Ucret>
	{
		public UcretConfiguration()
		{
			ToTable("Ucret");
			HasRequired(x => x.UcretTipi)
				.WithMany()
				.HasForeignKey(x => x.UcretTipiId);

			Property(x => x.UcretTL)
				.HasPrecision(18, 2);
		}
	}

}
