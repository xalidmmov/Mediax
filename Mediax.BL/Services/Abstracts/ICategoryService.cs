using Mediax.BL.ViewModels.Category;
using Mediax.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL.Services.Abstracts
{
	public interface ICategoryService
	{
		Task<List<Category>> GetAllAsync();
		Task<bool> Create(CategoryCreateVM vm);
		Task<bool> Update(int? id, CategoryCreateVM vm);
		Task<bool> Delete(int? id);
		Task<CategoryCreateVM> Get(int id);
	}
}
