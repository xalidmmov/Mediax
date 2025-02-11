using Mediax.Core.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.Core.Entites
{
	public class Product:BaseEntity
	{
		public string Name { get; set; } 
		public string Description { get; set; }  
		public decimal CostPrice { get; set; } 
		public decimal Price { get; set; }  
		public decimal? DiscountPrice { get; set; }  
		public string ImageUrl { get; set; } 
		public int StockQuantity { get; set; }  
		public Guid CategoryId { get; set; }
		public Category? Category { get; set; }
	}
}
