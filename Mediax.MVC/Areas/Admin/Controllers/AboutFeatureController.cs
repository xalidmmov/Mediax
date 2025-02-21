using Mediax.BL.Extensions;
using Mediax.BL.Services.Abstracts;
using Mediax.BL.Services.Implements;
using Mediax.BL.ViewModels.AboutFeature;
using Mediax.BL.ViewModels.Category;
using Mediax.Core.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mediax.MVC.Areas.Admin.Controllers
{
    public class AboutFeatureController(IAboutFeatureService _service, IWebHostEnvironment env) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var aboutfetaures = await _service.GetAllAsync();
            return View(aboutfetaures);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AboutFeatureCreateVm vm)
        {
            if (vm.CoverImg == null ||
      !vm.CoverImg.IsValidType("image") ||
      !vm.CoverImg.IsValidSize(3000))
            {
                ModelState.AddModelError("Image", "Please upload a valid image file less than 300 KB.");
                
                return View();
            }

            vm.AboutImg = await vm.CoverImg!.UploadAsync(env.WebRootPath, "abouts", "imgs");
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
            ViewBag.AllAboutFeatures = await _service.GetAllAsync();

            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, AboutFeatureCreateVm vm)
        {
            var data = await _service.Get(id);
            if (vm.CoverImg == null)
            {
                if (!vm.CoverImg!.IsValidType("image"))
                {
                    vm.AboutImg = data.AboutImg;
                    await _service.Update(id, vm);
                    return RedirectToAction(nameof(Index));
                }
            }

            vm.AboutImg = await vm.CoverImg!.UploadAsync(env.WebRootPath, "abouts", "imgs");
            await _service.Update(id, vm);

            return RedirectToAction(nameof(Index));
        }
    }
}
