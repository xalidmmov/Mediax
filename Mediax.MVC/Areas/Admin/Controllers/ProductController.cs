using Mediax.BL.Extensions;
using Mediax.BL.Services.Abstracts;
using Mediax.BL.Services.Implements;
using Mediax.BL.ViewModels.Doctor;
using Mediax.BL.ViewModels.Product;
using Mediax.Core.Entites;
using Mediax.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mediax.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
   // [Authorize(Roles = nameof(Roles.Admin))]
    public class ProductController(IProductService _service,ICategoryService categoryService,IWebHostEnvironment env): Controller
    {
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(categoryService.GetAllAsync().Result, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM vm)
        {
            if (vm.CoverImage == null ||
      !vm.CoverImage.IsValidType("image") ||
      !vm.CoverImage.IsValidSize(3000))
            {
                ModelState.AddModelError("Image", "Please upload a valid image file less than 300 KB.");
                ViewBag.Categories = new SelectList(categoryService.GetAllAsync().Result, "Id", "Name");
                return View();
            }

            vm.ProductImage = await vm.CoverImage!.UploadAsync(env.WebRootPath, "products", "imgs");
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
            var product = await _service.Get(id);
            if (product == null) return NotFound();

            ViewBag.Categories = new SelectList(await categoryService.GetAllAsync(), "Id", "Name");
            ViewBag.AllProducts = await _service.GetAllAsync(); 

            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, ProductCreateVM vm)
        {
            var data = await _service.Get(id);
            if (vm.CoverImage == null)
            {
                if (!vm.CoverImage!.IsValidType("image"))
                {
                    vm.ProductImage = data.ProductImage;
                    await _service.UpdateAsync(id, vm);
                    return RedirectToAction(nameof(Index));
                }
            }

            vm.ProductImage = await vm.CoverImage!.UploadAsync(env.WebRootPath, "products", "imgs");
            await _service.UpdateAsync(id, vm);

            return RedirectToAction(nameof(Index));

        }
    }
}
