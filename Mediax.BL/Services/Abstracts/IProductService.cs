using Mediax.BL.ViewModels.Doctor;
using Mediax.BL.ViewModels.Product;
using Mediax.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL.Services.Abstracts
{
	public interface IProductService
	{
        Task<List<Product>> GetAllAsync();
        Task<bool> Create(ProductCreateVM vm);
        Task<bool> Delete(int? id);
        Task<bool> UpdateAsync(int id, ProductCreateVM vm);
        Task<ProductCreateVM> Get(int id);
    }
}
