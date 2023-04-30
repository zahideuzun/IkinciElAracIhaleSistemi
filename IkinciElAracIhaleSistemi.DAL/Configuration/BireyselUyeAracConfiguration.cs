using IkinciElAracIhaleSistemi.Entities.Entities;
using System.Data.Entity.ModelConfiguration;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class BireyselUyeAracConfiguration : EntityTypeConfiguration<BireyselUyeArac>
	{
		public BireyselUyeAracConfiguration()
		{
			ToTable("BireyselUyeArac");
			HasKey(bua => bua.Id);

			HasRequired(bua => bua.BireyselUye)
				.WithMany()
				.HasForeignKey(bua => bua.BireyselUyeId)
				.WillCascadeOnDelete(false);

			HasMany(bua => bua.AldigiAraclar)
				.WithRequired(s => s.BireyselUyeArac)
				.HasForeignKey(s => s.BireyselUyeAracId)
				.WillCascadeOnDelete(false);
		}
	}



}
