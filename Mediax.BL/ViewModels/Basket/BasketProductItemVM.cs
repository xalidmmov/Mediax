using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL.ViewModels.Basket
{
    public class BasketProductItemVM
    {
        
            public int Id { get; set; }
            public int Count { get; set; }
            public BasketProductItemVM(int id)
            {
                Id = id;
                Count = 1;
            }
        
    }
}
