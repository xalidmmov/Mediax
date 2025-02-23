using Mediax.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL.Services.Abstracts
{
    public interface ICommentService
    {
        Task<bool> AddCommentAsync(int productId, string userId, string message);
        Task<List<Comment>> GetCommentsByProductAsync(int productId);
    }
}
