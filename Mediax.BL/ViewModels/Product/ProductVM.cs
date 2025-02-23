﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL.ViewModels.Product
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
