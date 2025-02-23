using Mediax.BL.Services.Abstracts;
using Mediax.BL.Services.Implements;
using Mediax.BL.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace Mediax.MVC.Controllers
{
    public class ProductController(IProductService _productService, IProductDetailService _productDetailService) : Controller
    {
        public async Task<IActionResult> Index(int page = 1, int pageSize = 8)
        {
            var totalProducts = await _productService.GetAllAsync();
            int totalCount = totalProducts.Count;
            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var products = totalProducts
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ProductVM
                {
                    Name = p.Name,
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    DiscountPrice = p.DiscountPrice,
                    CategoryName = p.Category != null ? p.Category.Name : "No Category"
                }).ToList();

            var paginatedVM = new PaginatedProductVM
            {
                Products = products,
                CurrentPage = page,
                TotalPages = totalPages
            };

            return View(paginatedVM);
        }
        [HttpGet]
        public async Task< IActionResult> Details(int id)
        {
            var productDetails = await _productDetailService.GetProductDetailsAsync(id);
            if (productDetails == null) return NotFound();

            return View(productDetails);
        }
        [HttpPost]
        public async Task<IActionResult> AddRating(int productId, string userId, int ratingValue)
        {
            bool success = await _productDetailService.AddRatingAsync(productId, userId, ratingValue);
            if (!success) return BadRequest("Invalid rating value.");

            return RedirectToAction("Details", new { id = productId });
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(int productId, string userId, string message)
        {
            bool success = await _productDetailService.AddCommentAsync(productId, userId, message);
            if (!success) return BadRequest("Comment cannot be empty.");

            return RedirectToAction("Details", new { id = productId });
        }


    }
}
