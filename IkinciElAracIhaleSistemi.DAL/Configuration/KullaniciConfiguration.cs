
using System.Data.Entity.ModelConfiguration;
using IkinciElAracIhaleSistemi.Entities.Entities;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class KullaniciConfiguration : EntityTypeConfiguration<Kullanici>
	{
		public KullaniciConfiguration()
		{
			ToTable("Kullanici");

			HasKey(k => k.KullaniciId);
			Property(t => t.Isim)
				.IsRequired()
				.HasMaxLength(50);
				
				Property(t => t.Soyisim)
			.IsRequired()
			.HasMaxLength(50);

			Property(t => t.KullaniciAdi)
			.IsRequired()
			.HasMaxLength(50);

			Property(t => t.Sifre)
			.IsRequired()
			.HasMaxLength(20);

			Property(t => t.Telefon)
			.HasMaxLength(20);

			Property(t => t.Mail)
				.HasMaxLength(150);


			HasRequired(k => k.Rol)
				.WithMany()
				.HasForeignKey(k => k.RolId).WillCascadeOnDelete(false);

			HasMany(k => k.Araclar)
				.WithRequired(a => a.Kullanici)
				.HasForeignKey(a => a.KullaniciId);

			HasMany(k => k.KullaniciIletisim)
				.WithRequired(i => i.Kullanici)
				.HasForeignKey(i => i.KullaniciId);

			HasMany(k => k.Ihaleler)
				.WithRequired(i => i.Kullanici)
				.HasForeignKey(i => i.KullaniciId);
		}
	}

}
