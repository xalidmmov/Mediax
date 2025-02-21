using Mediax.BL.ViewModels.Doctor;
using Mediax.BL.ViewModels.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL.ViewModels.Home
{
    public class HomeVM
    {
        public List<ServiceVm> Services { get; set; } = new();
        public List<DoctorVM> Doctors { get; set; } = new();
    }
}
