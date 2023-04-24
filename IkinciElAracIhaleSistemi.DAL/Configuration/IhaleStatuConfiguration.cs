using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class IhaleStatuConfiguration : EntityTypeConfiguration<IhaleStatu>
	{
		public IhaleStatuConfiguration()
		{
			
			ToTable("IhaleStatu");
			HasKey(isu => isu.IhaleStatuId);

			HasRequired(isu => isu.Ihale)
				.WithMany(i => i.IhaleStatu)
				.HasForeignKey(isu => isu.IhaleId);

			HasRequired(isu => isu.Statu)
				.WithMany()
				.HasForeignKey(isu => isu.StatuId);
		}

	}
}
