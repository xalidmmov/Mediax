using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL.ViewModels.Doctor
{
    public class DoctorVM
    {
        public string FullName { get; set; } = null!;
        public string Specialization { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
