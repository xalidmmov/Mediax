using Mediax.BL.Services.Abstracts;
using Mediax.Core.Entites;
using Mediax.Dal.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL.Services.Implements
{
    public class RatingService(MediaxDbContext _context) : IRatingService
    {
        public async Task<bool> AddRatingAsync(int productId, string userId, int value)
        {
            if (value < 1 || value > 5) return false;

            var rating = new Rating
            {
                ProductId = productId,
                UserId = userId,
                Value = value,
                CreatedTime = DateTime.Now
            };

            await _context.Ratings.AddAsync(rating);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Rating>> GetRatingsByProductAsync(int productId)
        {
            return await _context.Ratings
                .Where(r => r.ProductId == productId)
                .Include(r => r.User)
                .ToListAsync();
        }
    }

}
