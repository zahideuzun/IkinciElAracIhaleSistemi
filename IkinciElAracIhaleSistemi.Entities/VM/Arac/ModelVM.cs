using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IkinciElAracIhaleSistemi.Entities.VM.Arac
{
	public class ModelVM
	{
		public int ModelId { get; set; }
		public string ModelAdi { get; set; }
		public List<SelectListItem> Modeller { get; set; }
	}
}
