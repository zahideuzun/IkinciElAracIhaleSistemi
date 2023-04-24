using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class AracStatuConfiguration : EntityTypeConfiguration<AracStatu>
	{
		public AracStatuConfiguration()
		{
			
			ToTable("AracStatu"); 
			HasKey(a => a.Id); 
			Property(a => a.Tarih).IsRequired();
			
			HasRequired(a => a.Arac)
				.WithMany(a => a.AracStatu)
				.HasForeignKey(a => a.AracId);
			
			HasRequired(a => a.Statu)
				.WithMany(a => a.AracStatuList)
				.HasForeignKey(a => a.StatuId);
		} 
	}
}
