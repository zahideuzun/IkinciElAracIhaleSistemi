﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemi.Entities.Entities.Bases;

namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class AracIhale : BaseEntity
	{
		public int AracId { get; set; }
		public int IhaleId { get; set; }
		public decimal IhaleBaslangicFiyati { get; set; }
		public decimal MinimumAlimFiyati { get; set; }
		public Arac Arac { get; set; }
		public Ihale Ihale { get; set; }
		public ICollection<AracTeklif> AracTeklifler { get;  set; }
	}
}
