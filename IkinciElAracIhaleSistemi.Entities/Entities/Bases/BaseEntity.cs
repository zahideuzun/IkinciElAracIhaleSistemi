using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.Entities.Entities.Bases
{
	public class BaseEntity : IEntity
	{
		[Key]
		public int Id { get; set; }
		public int CreatedBy { get; set; } = 1;
		public DateTime? CreatedDate { get; set; } = DateTime.Now;
		public int? ModifiedBy { get; set; } 
		public DateTime? ModifiedDate { get; set; } = DateTime.Now;
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
	}
}
