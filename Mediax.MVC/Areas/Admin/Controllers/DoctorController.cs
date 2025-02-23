using Mediax.BL.Extensions;
using Mediax.BL.Services.Abstracts;
using Mediax.BL.Services.Implements;
using Mediax.BL.ViewModels.Doctor;
using Mediax.BL.ViewModels.Service;
using Mediax.Core.Entites;
using Mediax.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mediax.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
 //  [Authorize(Roles = nameof(Roles.Admin))]
    public class DoctorController (IDoctorService _service,IDepartmentService departmentService,IWebHostEnvironment env): Controller
    {
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Departments = new SelectList(departmentService.GetAllAsync().Result, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DoctorCreateVM vm)
        {
            if (vm.CoverImage == null ||
      !vm.CoverImage.IsValidType("image") ||
      !vm.CoverImage.IsValidSize(3000))
            {
                ModelState.AddModelError("Image", "Please upload a valid image file less than 300 KB.");
                ViewBag.Departments = new SelectList(departmentService.GetAllAsync().Result, "Id", "Name");
                return View();
            }

            vm.DoctorImage = await vm.CoverImage!.UploadAsync(env.WebRootPath, "doctors", "imgs");
            await _service.Create(vm);
            return RedirectToAction(nameof(Index));




        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue) return BadRequest();

            bool condition = await _service.Delete(id);

            if (!condition) return NotFound();

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var doctor = await _service.Get(id);
            if (doctor == null) return NotFound();

            ViewBag.Departments = new SelectList(await departmentService.GetAllAsync(), "Id", "Name");
            ViewBag.AllDoctors = await _service.GetAllAsync(); 

            return View(doctor);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, DoctorCreateVM vm)
        {
            var data = await _service.Get(id);
            if (vm.CoverImage == null)
            {
                if (!vm.CoverImage!.IsValidType("image"))
                {
                    vm.DoctorImage = data.DoctorImage;
                    await _service.UpdateAsync(id, vm);
                    return RedirectToAction(nameof(Index));
                }
            }

            vm.DoctorImage = await vm.CoverImage!.UploadAsync(env.WebRootPath, "doctors", "imgs");
            await _service.UpdateAsync(id, vm);

            return RedirectToAction(nameof(Index));

        }
    }
}
