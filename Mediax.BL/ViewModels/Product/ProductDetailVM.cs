using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL.ViewModels.Product
{
    public class ProductDetailVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string CategoryName { get; set; } = null!;

        public List<RatingVM> Ratings { get; set; } = new();
        public List<CommentVM> Comments { get; set; } = new();
    }
}
