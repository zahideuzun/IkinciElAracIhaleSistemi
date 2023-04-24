
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class FirmaConfiguration : EntityTypeConfiguration<Firma>
	{
		public FirmaConfiguration()
		{
			ToTable("Firma");

			Property(f => f.Unvan)
				.IsRequired()
				.HasMaxLength(50);

			Property(f => f.FirmaTuruId)
				.IsRequired();

			Property(f => f.PaketId)
				.IsRequired();

			Property(f => f.SehirIlceId)
				.IsRequired();

			HasRequired(f => f.FirmaTuru)
				.WithMany(ft => ft.Firmalar)
				.HasForeignKey(f => f.FirmaTuruId)
				.WillCascadeOnDelete(false);

			HasRequired(f => f.Paket)
				.WithMany()
				.HasForeignKey(f => f.PaketId)
				.WillCascadeOnDelete(false);

			HasRequired(f => f.SehirIlce)
				.WithMany()
				.HasForeignKey(f => f.SehirIlceId)
				.WillCascadeOnDelete(false);

			HasMany(f => f.FirmaIletisimler)
				.WithRequired(fi => fi.Firma)
				.HasForeignKey(fi => fi.FirmaId)
				.WillCascadeOnDelete(false);

			HasMany(f => f.Stoklar)
				.WithRequired(s => s.Firma)
				.HasForeignKey(s => s.FirmaId)
				.WillCascadeOnDelete(false);

			HasMany(f => f.KurumsalUyeler)
				.WithRequired(ku => ku.Firma)
				.HasForeignKey(ku => ku.FirmaId)
				.WillCascadeOnDelete(false);
		}
	}

}
