using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class FavoriOzellikConfiguration : EntityTypeConfiguration<FavoriOzellik>
	{
		public FavoriOzellikConfiguration()
		{
			
			ToTable("FavoriOzellik");

			HasRequired(fo => fo.OzellikDetay)
				.WithMany()
				.HasForeignKey(fo => fo.OzellikDetayId)
				.WillCascadeOnDelete(false);

			HasRequired(fo => fo.FavoriAramaKriter)
				.WithMany()
				.HasForeignKey(fo => fo.FavoriAramaKriterId)
				.WillCascadeOnDelete(false);
		}
	}
}
