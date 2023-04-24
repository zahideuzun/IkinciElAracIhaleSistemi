using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Entities
{
	public class FavoriIlan
	{
		public int FavoriIlanId { get; set; }
		public int UyeId { get; set; }
		public int IlanId { get; set; }
		public DateTime Tarih { get; set; }
		public Ilan Ilan { get; set; }
		public Uye Uye { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
	}
}
