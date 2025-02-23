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
    public class CommentService(MediaxDbContext _context) : ICommentService
    {
        public async Task<bool> AddCommentAsync(int productId, string userId, string message)
        {
            if (string.IsNullOrWhiteSpace(message)) return false;

            var comment = new Comment
            {
                ProductId = productId,
                UserId = userId,
                Message = message,
                CreatedTime = DateTime.Now
            };

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Comment>> GetCommentsByProductAsync(int productId)
        {
            return await _context.Comments
                .Where(c => c.ProductId == productId)
                .Include(c => c.User)
                .ToListAsync();
        }
    }
}
