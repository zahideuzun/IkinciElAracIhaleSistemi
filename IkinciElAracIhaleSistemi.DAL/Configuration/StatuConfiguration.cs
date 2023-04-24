using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class StatuConfiguration : EntityTypeConfiguration<Statu>
	{
		public StatuConfiguration()
		{
			
			ToTable("Statu"); 
			HasKey(s => s.StatuId); 
			Property(s => s.StatuAdi).IsRequired(); 
			Property(s => s.IsActive).IsRequired(); 
			Property(s => s.IsDeleted).IsRequired();
			
			HasMany(s => s.AracStatuList)
			.WithRequired(a => a.Statu)
			.HasForeignKey(a => a.StatuId);

			
			HasMany(s => s.IhaleStatuList)
				.WithRequired(i => i.Statu)
				.HasForeignKey(i => i.StatuId);
		} 
	}
}