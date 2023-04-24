using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class RolConfiguration : EntityTypeConfiguration<Rol>
	{
		public RolConfiguration()
		{
			
			ToTable("Rol"); 
			HasKey(r => r.RolId); 
			Property(r => r.RolAdi).IsRequired(); 
			Property(r => r.IsActive).IsRequired(); 
			Property(r => r.IsDeleted).IsRequired();

			
			//HasMany(r => r.Uyeler)
			//	.WithMany(u => u.Roller)
			//	.Map(m =>
			//	{
			//		m.ToTable("UyeRol"); 
			//		m.MapLeftKey("RolId"); 
			//		m.MapRightKey("UyeId");
			//	});

			
			//HasMany(r => r.Kullanicilar)
			//	.WithMany(k => k.Roller)
			//	.Map(m =>
			//	{
			//		m.ToTable("KullaniciRol"); 
			//		m.MapLeftKey("RolId"); 
			//		m.MapRightKey("KullaniciId"); 
			//	});

			
			//HasMany(r => r.KurumsalUyeler)
			//	.WithMany(k => k.Roller)
			//	.Map(m =>
			//	{
			//		m.ToTable("KurumsalUyeRol"); 
			//		m.MapLeftKey("RolId"); 
			//		m.MapRightKey("KurumsalUyeId"); 
			//	});
		}
	}


}
