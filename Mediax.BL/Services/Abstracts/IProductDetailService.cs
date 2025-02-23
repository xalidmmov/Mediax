using Mediax.BL.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL.Services.Abstracts
{
    public interface IProductDetailService
    {
        Task<ProductDetailVM> GetProductDetailsAsync(int productId);
        Task<bool> AddRatingAsync(int productId, string userId, int ratingValue);
        Task<bool> AddCommentAsync(int productId, string userId, string message);
    }
}
