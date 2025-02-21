using Mediax.BL.Services.Abstracts;
using Mediax.BL.ViewModels.Doctor;
using Mediax.BL.ViewModels.Product;
using Mediax.Core.Entites;
using Mediax.Dal.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL.Services.Implements
{
    public class ProductService (MediaxDbContext _context): IProductService
    {
        public async Task<bool> Create(ProductCreateVM vm)
        {
            await _context.Products.AddAsync(new Product
            {
                Name= vm.Name,
                Description=vm.Description,
                CostPrice=vm.CostPrice,
                Price=vm.SellPrice,
                DiscountPrice=vm.Discount,
                StockQuantity=vm.Quantity,
                ImageUrl=vm.ProductImage,
                CategoryId=vm.CategoryId,

                


            });
            await _context.SaveChangesAsync();
            return false;
        }

        public async Task<bool> Delete(int? id)
        {
            var data = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                _context.Products.Remove(data);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<ProductCreateVM> Get(int id)
        {
            var data = await _context.Products.FindAsync(id);
            ProductCreateVM vm = new ProductCreateVM
            {
                Name = data.Name,
                Description = data.Description,
                Quantity=data.StockQuantity,
                SellPrice = data.Price,
                Discount = data.DiscountPrice,
                ProductImage = data.ImageUrl,
                CategoryId = data.CategoryId,
            };
            return vm;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.Where(x => x.IsDeleted == false).Include(x => x.Category).ToListAsync();
        }

        public async Task<bool> UpdateAsync(int id, ProductCreateVM vm)
        {
            var data = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                data.Name = vm.Name;
                data.CategoryId = vm.CategoryId;
                data.ImageUrl = vm.ProductImage;
                data.CostPrice= vm.CostPrice;
                data.Price=vm.SellPrice;
                data.StockQuantity=vm.Quantity;
                data.Description = vm.Description;
                await _context.SaveChangesAsync();
                return true;

            };
            return false;

        }
    }
}
