using Mediax.BL.Services.Abstracts;
using Mediax.BL.ViewModels.Doctor;
using Mediax.BL.ViewModels.Service;
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
	public class ServiceService(MediaxDbContext _context) : IServiceService
	{
		public async Task<bool> Create(ServiceCreateVM vm)
		{
			await _context.Services.AddAsync(new Service
			{
				Name = vm.SName,
				
				DepartmentId = vm.DepartmentId,
				IconUrl = vm.ServiceImg

			});
			await _context.SaveChangesAsync();
			return false;
		}

		public async Task<bool> Delete(int? id)
		{
			var data = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);
			if (data != null)
			{
				_context.Services.Remove(data);
				await _context.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<ServiceCreateVM> Get(int id)
		{
			var data = await _context.Services.FindAsync(id);
			ServiceCreateVM vm = new ServiceCreateVM
			{
				SName=data.Name,
				DepartmentId = data.DepartmentId,
				ServiceImg = data.IconUrl
			};
			return vm;
		}

		public async Task<List<Service>> GetAllAsync()
		{
			return await _context.Services.Where(x => x.IsDeleted == false).Include(x => x.Department).ToListAsync();
		}

		public async Task<bool> UpdateAsync(int id, ServiceCreateVM vm)
		{
			var data = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);
			if (data != null)
			{
				data.Name = vm.SName;
				data.DepartmentId = vm.DepartmentId;
				data.IconUrl = vm.ServiceImg;
				await _context.SaveChangesAsync();
				return true;

			};
			return false;

		}
	}
}
