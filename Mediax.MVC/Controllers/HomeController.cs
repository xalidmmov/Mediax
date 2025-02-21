
using Mediax.BL.Services.Abstracts;
using Mediax.BL.ViewModels.Doctor;
using Mediax.BL.ViewModels.Home;
using Mediax.BL.ViewModels.Service;
using Mediax.Core.Entites;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Mediax.MVC.Controllers
{
	public class HomeController(IServiceService _service, IDoctorService _doctorService) : Controller
	{


        public async Task<IActionResult> Index()
        {
            var services = await _service.GetAllAsync();
            var doctors = await _doctorService.GetAllAsync();

            var homeVM = new HomeVM
            {
                Services = services.Select(s => new ServiceVm
                {
                    Name = s.Name,
                    IconUrl = s.IconUrl
                }).ToList(),

                Doctors = doctors.Select(d => new DoctorVM
                {
                    FullName = d.FullName,
                    Specialization = d.Specialization,
                    ImageUrl = d.ImageUrl
                }).ToList()
            };

            return View(homeVM);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Service()
        {
            return View();
        }
        public IActionResult Contact()
        {
                return View();
        }

    }
}
