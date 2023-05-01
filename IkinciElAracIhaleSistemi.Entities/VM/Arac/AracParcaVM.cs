using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IkinciElAracIhaleSistemi.Entities.VM.Arac
{
	public class AracParcaVM
	{
		public int AracParcaId { get; set; }
		public string AracParcaAdi { get; set; }
		public List<SelectListItem> Parcalar { get; set; }
	}
}
