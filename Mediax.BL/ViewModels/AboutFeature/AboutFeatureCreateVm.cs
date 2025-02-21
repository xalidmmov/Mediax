using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL.ViewModels.AboutFeature
{
    public class AboutFeatureCreateVm
    {
        [Required, MaxLength(32)]
        public string Title { get; set; }
        [Required, MaxLength(155)]
        public string Description { get; set; } 
        public string? AboutImg { get; set; } 
        public IFormFile? CoverImg { get; set; }
    }
}
