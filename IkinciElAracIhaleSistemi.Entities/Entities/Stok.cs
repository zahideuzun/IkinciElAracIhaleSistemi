﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities.Bases;

namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class Stok : BaseEntity
	{
		public int FirmaId { get; set; }
		public int AracId { get; set; }
		public DateTime Tarih { get; set; }

		public Arac Arac { get; set; }
		public Firma Firma { get; set; }
	}
}
