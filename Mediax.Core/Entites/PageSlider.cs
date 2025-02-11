using Mediax.Core.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.Core.Entites
{
	public class PageSlider: BaseEntity
	{
		public string PageName { get; set; } 
		public IEnumerable<SliderImage> Images { get; set; }
	}
}
