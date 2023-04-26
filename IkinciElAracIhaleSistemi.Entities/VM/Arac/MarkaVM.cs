using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IkinciElAracIhaleSistemi.Entities.VM.Arac
{
	public class MarkaVM
	{
		public int MarkaId { get; set; }
		public string MarkaAdi { get; set; }
		public List<SelectListItem> Markalar { get; set; }
	}
}
