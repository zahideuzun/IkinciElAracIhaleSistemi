using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IkinciElAracIhaleSistemi.Entities.VM.Arac
{
	public class AracTramerVM
	{
		public int TramerDurumId { get; set; }
		public string TramerDurumAdi { get; set; }
		public decimal TramerTutari { get; set; }
	}
}
