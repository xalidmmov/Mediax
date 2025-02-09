using Mediax.Core.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.Core.Entites
{
	public class Department:BaseEntity
	{
		public string Name { get; set; } 
		
		public IEnumerable<Service> Services { get; set; }
	}
}
