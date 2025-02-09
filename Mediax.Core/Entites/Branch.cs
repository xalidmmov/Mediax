using Mediax.Core.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.Core.Entites
{
	public class Branch:BaseEntity
	{
		public string Name { get; set; }
		public string Address { get; set; }  
		public string Email { get; set; }  
		public string Phone { get; set; } 
		public string OpeningHours { get; set; } 
	}
}
