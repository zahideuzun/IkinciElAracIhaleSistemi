﻿using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class KurumsalUyeConfiguration : EntityTypeConfiguration<KurumsalUye>
	{
		public KurumsalUyeConfiguration()
		{
			
			ToTable("KurumsalUye");


			HasRequired(k => k.Uye)
				.WithMany()
				.HasForeignKey(k => k.UyeId);

			HasRequired(k => k.Firma)
				.WithMany()
				.HasForeignKey(k => k.FirmaId);

			HasRequired(k => k.Rol)
				.WithMany()
				.HasForeignKey(k => k.RolId);

			Property(k => k.OnaylandiMi).IsRequired();
		}
	}


}
