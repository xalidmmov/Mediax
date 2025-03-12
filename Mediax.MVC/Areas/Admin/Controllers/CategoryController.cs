using Mediax.BL.Services.Abstracts;
using Mediax.BL.ViewModels.Category;
using Mediax.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mediax.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public class CategoryController(ICategoryService _service) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _service.GetAllAsync();
            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateVM vm)
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
        public async Task<IActionResult> Update(int id, CategoryCreateVM vm)
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
