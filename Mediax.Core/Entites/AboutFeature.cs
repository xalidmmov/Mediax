using Mediax.Core.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.Core.Entites
{
    public class AboutFeature:BaseEntity
    {
        public string Title { get; set; } 
        public string Description { get; set; }  
        public string IconUrl { get; set; } 
    }
}
