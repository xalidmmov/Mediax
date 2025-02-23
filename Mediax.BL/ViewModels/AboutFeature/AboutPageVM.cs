using Mediax.BL.ViewModels.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL.ViewModels.AboutFeature
{
    public class AboutPageVM
    {
        public List<AboutFeatureCreateVm> Features { get; set; } = new();
        public List<DoctorVM> Doctors { get; set; } = new();
    }
}
