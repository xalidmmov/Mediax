using Mediax.Core.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.Core.Entites
{
    public class Comment:BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public string UserId { get; set; }
        public User User { get; set; } = null!;
        

        public string Message { get; set; } = null!;
    }
}
