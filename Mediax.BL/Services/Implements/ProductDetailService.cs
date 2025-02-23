using Mediax.BL.Services.Abstracts;
using Mediax.BL.ViewModels.Product;
using Mediax.Dal.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL.Services.Implements
{
    public class ProductDetailService(MediaxDbContext _context) : IProductDetailService
    {
        public async Task<ProductDetailVM> GetProductDetailsAsync(int productId)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Ratings)
                .Include(p => p.Comments)
                .ThenInclude(c => c.User) 
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null) return null;

            return new ProductDetailVM
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                DiscountPrice = product.DiscountPrice,
                ImageUrl = product.ImageUrl,
                CategoryName = product.Category.Name,
                Ratings = product.Ratings.Select(r => new RatingVM
                {
                    Value = r.Value,
                    UserId = r.UserId
                }).ToList(),
                Comments = product.Comments.Select(c => new CommentVM
                {
                    FullName = c.User.FullName,
                    Message = c.Message,
                    CreatedTime = c.CreatedTime
                }).ToList()
            };
        }

        public async Task<bool> AddRatingAsync(int productId, string userId, int ratingValue)
        {
            return await new RatingService(_context).AddRatingAsync(productId, userId, ratingValue);
        }

        public async Task<bool> AddCommentAsync(int productId, string userId, string message)
        {
            return await new CommentService(_context).AddCommentAsync(productId, userId, message);
        }
    }
}
