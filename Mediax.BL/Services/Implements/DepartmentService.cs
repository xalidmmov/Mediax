using Mediax.BL.Services.Abstracts;
using Mediax.BL.ViewModels.Category;
using Mediax.BL.ViewModels.Department;
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
	public class DepartmentService(MediaxBdContext _context) : IDepartmentService
	{
		//public async Task<bool> Create(DepartmentCreateVM vm)
		//{
		//	await _context.AddAsync(new Category
		//	{
		//		CName = vm.Name

		//	});
		//	await _context.SaveChangesAsync();
		//	return true;
		//}

		//public async Task<bool> Delete(int? id)
		//{
		//	var data = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
		//	if (data != null)
		//	{
		//		_context.Categories.Remove(data);
		//		await _context.SaveChangesAsync();
		//		return true;
		//	}
		//	return false;
		//}

		//public async Task<DepartmentCreateVM> Get(int id)
		//{
		//	var data = await _context.Categories.FindAsync(id);
		//	DepartmentCreateVM vm = new()
		//	{
		//		Name = data!.CName,


		//	};
		//	return vm;
		//}

		//public async Task<List<Department>> GetAllAsync()
		//{
		//	return await _context.Categories.ToListAsync();
		//}

		//public async Task<bool> Update(int? id, DepartmentCreateVM vm)
		//{
		//	var data = await _context.Categories.FirstOrDefaultAsync();
		//	if (data != null)
		//	{
		//		data.CName = vm.Name;
		//		await _context.SaveChangesAsync();
		//		return true;
		//	}
		//	return false;
		//}
	}
}
