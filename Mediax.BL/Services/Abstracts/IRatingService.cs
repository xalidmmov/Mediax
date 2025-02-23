using Mediax.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL.Services.Abstracts
{
    public interface IRatingService
    {
        Task<bool> AddRatingAsync(int productId, string userId, int value);
        Task<List<Rating>> GetRatingsByProductAsync(int productId);
    }
}
