
using Mediax.BL.Services.Abstracts;
using Mediax.BL.ViewModels.AboutFeature;
using Mediax.BL.ViewModels.Apointment;
using Mediax.BL.ViewModels.Doctor;
using Mediax.BL.ViewModels.Home;
using Mediax.BL.ViewModels.Service;
using Mediax.Core.Entites;
using Mediax.Dal.DAL;
using Mediax.Dal.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Mediax.MVC.Controllers
{
	public class HomeController(IServiceService _service, IDoctorService _doctorService,MediaxDbContext _context) : Controller
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
                }).ToList(),
                Appointment = new AppointmentVM()
        };
            
            return View(homeVM);
        }
        
            public async Task<IActionResult> About()
            {
                var features = await _context.AboutFeatures
                    .Select(x => new AboutFeatureCreateVm
                    {
                        Title = x.Title,
                        Description = x.Description,
                        AboutImg = x.IconUrl
                    }).ToListAsync();

                var doctors = await _doctorService.GetAllAsync();

                var aboutPageVM = new AboutPageVM
                {
                    Features = features,
                    Doctors = doctors.Select(d => new DoctorVM
                    {
                        FullName = d.FullName,
                        Specialization = d.Specialization,
                        ImageUrl = d.ImageUrl
                    }).ToList()
                };

                return View(aboutPageVM);
            }

        public async Task<IActionResult> Service()
        {
            var services = await _service.GetAllAsync();

            var serviceVMs = services.Select(s => new ServiceVm
            {
                Name = s.Name,
                IconUrl = s.IconUrl
            }).ToList();

            return View(serviceVMs);
        }
        public IActionResult Contact()
        {
                return View();
        }
        [HttpPost]       
        
        public async Task<IActionResult> BookAppointment(AppointmentVM vm)
        {

            if (!ModelState.IsValid)
            {
                var homeVM = new HomeVM
                {
                    Appointment = vm 
                };

                return View("Index", homeVM);
            }

            var appointment = new Apointment
            {
                FullName = vm.FullName,
                Email = vm.Email,
                Phone = vm.Phone,
                AppointmentDate = vm.AppointmentDate,
                Message = vm.Message,
                CreatedTime = DateTime.Now
            };

            _context.Apointsments.Add(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Team()
        {
            var doctors = await _doctorService.GetAllAsync();
            var doctorVMs = doctors.Select(d => new DoctorVM
            {
                FullName = d.FullName,
                Specialization = d.Specialization,
                ImageUrl = d.ImageUrl
            }).ToList();

            return View(doctorVMs);
        }
    }

}