using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.Core.Entites.Common
{
	public class BaseEntity
	{
		public int Id { get; set; } 
		public bool IsDeleted { get; set; } = false; 
		public DateTime CreatedTime { get; set; } = DateTime.Now;  
	}
}
