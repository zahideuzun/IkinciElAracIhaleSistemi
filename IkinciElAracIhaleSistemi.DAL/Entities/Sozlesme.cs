using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Entities
{
	public class Sozlesme
	{
		public int SozlesmeId { get; set; }
		public int SozlesmePath { get; set; }
		public DateTime SozlesmeTarih { get; set; }
		public int SozlesmeTuruId { get; set; }
		public SozlesmeTuru SozlesmeTuru { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
	}
}
