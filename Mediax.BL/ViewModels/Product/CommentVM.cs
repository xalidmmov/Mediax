using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL.ViewModels.Product
{
    public class CommentVM
    {
        public string FullName { get; set; } = null!;
        public string Message { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
    }
}
