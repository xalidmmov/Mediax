using Mediax.Core.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.Core.Entites
{
	public class SliderImage:BaseEntity
	{
		public Guid PageSliderId { get; set; } 
		public string ImageUrl { get; set; }  
		public string Caption { get; set; }
	}
}
