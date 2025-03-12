using Mediax.BL.Extensions;
using Mediax.BL.Services.Abstracts;
using Mediax.BL.Services.Implements;
using Mediax.BL.ViewModels.Service;
using Mediax.Core.Entites;
using Mediax.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mediax.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public class ServiceController (IServiceService _service,IDepartmentService departmentService,IWebHostEnvironment env): Controller
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
        public async Task<IActionResult> Create(ServiceCreateVM vm)
        {
            if (vm.CoverSImage == null ||
      !vm.CoverSImage.IsValidType("image") ||
      !vm.CoverSImage.IsValidSize(3000))
            {
                ModelState.AddModelError("Image", "Please upload a valid image file less than 300 KB.");
                ViewBag.Departments = new SelectList(departmentService.GetAllAsync().Result, "Id", "Name");
                return View();
            }

            vm.ServiceImg = await vm.CoverSImage!.UploadAsync(env.WebRootPath, "services", "imgs");
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
            var service = await _service.Get(id);
            if (service == null) return NotFound();

            ViewBag.Departments = new SelectList(await departmentService.GetAllAsync(), "Id", "Name");
            ViewBag.AllServices = await _service.GetAllAsync();

            return View(service);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, ServiceCreateVM vm)
        {
            var data = await _service.Get(id);
            if (vm.CoverSImage == null)
            {
                if (!vm.CoverSImage!.IsValidType("image"))
                {
                    vm.ServiceImg = data.ServiceImg;
                    await _service.UpdateAsync(id, vm);
                    return RedirectToAction(nameof(Index));
                }
            }

            vm.ServiceImg = await vm.CoverSImage!.UploadAsync(env.WebRootPath, "services", "imgs");
            await _service.UpdateAsync(id, vm);

            return RedirectToAction(nameof(Index));

        }
    }
}
