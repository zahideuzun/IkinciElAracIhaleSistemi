﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.Entities.VM.Arac
{
	public class AracTramerDetayEklemeVM
	{
		public int AracId { get; set; }
		public decimal Fiyat { get; set; }
		public AracTramerDetayChildVM[] Children { get; set; }
	}

	public class AracTramerDetayChildVM
	{
		public int ParcaId { get; set; }
		public int TramerId { get; set; }
	}
}
