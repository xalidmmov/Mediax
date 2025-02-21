using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL.ViewModels.Product
{
	public class ProductCreateVM
	{
		[Required, MaxLength(32)]
		public string Name { get; set; } = null!;
		[MaxLength(64), Required(ErrorMessage = "Must be fill")]
		public string Description { get; set; } = null!;
		
		public decimal CostPrice { get; set; }
		[Required(ErrorMessage = "Must be fill")]
		public decimal SellPrice { get; set; }
		[Required(ErrorMessage = "Must be fill")]
		public int Quantity { get; set; }
		
		public decimal? Discount { get; set; }
		public int CategoryId { get; set; }
		public IFormFile? CoverImage { get; set; }
		public string? ProductImage { get; set; }
	}
}
