using Mediax.Core.Entites.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.Core.Entites
{
	public class Category:BaseEntity
	{
		public string Name { get; set; } 
		public IEnumerable<Product>? Products { get; set; }
	}
}
