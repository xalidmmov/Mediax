using Mediax.BL.Services.Abstracts;
using Mediax.BL.ViewModels.Category;
using Mediax.BL.ViewModels.Department;
using Mediax.Core.Entites;
using Mediax.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mediax.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public class DepartmentController(IDepartmentService _service) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var departments = await _service.GetAllAsync();
            return View(departments);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _service.Create(vm);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var data = await _service.Get(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, DepartmentCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _service.Update(id, vm);
            return View();
        }

    }
}
