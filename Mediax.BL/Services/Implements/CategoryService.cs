using Mediax.BL.Services.Abstracts;
using Mediax.BL.ViewModels.Category;
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
	public class CategoryService(MediaxDbContext _context) : ICategoryService
	{
		public async Task<bool> Create(CategoryCreateVM vm)
		{
			await _context.Categories.AddAsync(new Category
			{
				Name = vm.Name

			});
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<bool> Delete(int? id)
		{
			var data = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
			if (data != null)
			{
				_context.Categories.Remove(data);
				await _context.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<CategoryCreateVM> Get(int id)
		{
			var data = await _context.Categories.FindAsync(id);
			CategoryCreateVM vm = new()
			{
				Name = data!.Name


			};
			return vm;


		}

		public async Task<List<Category>> GetAllAsync()
		{
			return await _context.Categories.ToListAsync();
		}

		public async Task<bool> Update(int? id, CategoryCreateVM vm)
		{
			var data = await _context.Categories.FirstOrDefaultAsync();
			if (data != null)
			{
				data.Name = vm.Name;
				await _context.SaveChangesAsync();
				return true;
			}
			return false;
		}
	}
}
