﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.Entities.VM.Arac
{
	public class AracStatuVM
	{
		public int AracId { get; set; }
		public int StatuId { get; set; }
		public string StatuAdi { get; set; }
		public string AktifMi { get; set; }
		public DateTime Tarih { get; set; }

	}
}
