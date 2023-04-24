using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class IhaleTuruConfiguration : EntityTypeConfiguration<IhaleTuru>
	{
		public IhaleTuruConfiguration()
		{
			
			ToTable("IhaleTuru");
			HasKey(it => it.IhaleTuruId);

			Property(it => it.IhaleTuruAdi)
				.HasMaxLength(50)
				.IsRequired();

			HasMany(it => it.Ihale)
				.WithRequired(i => i.IhaleTuru)
				.HasForeignKey(i => i.IhaleTuruId);
		}

	}
}
