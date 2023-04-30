using IkinciElAracIhaleSistemi.Entities.Entities.Bases;
using System.Collections.Generic;

namespace IkinciElAracIhaleSistemi.Entities.Entities
{
	public class BireyselUyeArac : BaseEntity
	{
		public int BireyselUyeId { get; set; }
		
		public BireyselUye BireyselUye { get; set; }
		public ICollection<Satis> AldigiAraclar { get; set; }
	}
}
