using Mediax.BL.Services.Abstracts;
using Mediax.BL.ViewModels.Doctor;
using Mediax.Core.Entites;
using Mediax.Dal.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mediax.BL.Services.Implements
{
	public class DoctorService(MediaxDbContext _context) : IDoctorService
	{
		public async Task<bool> Create(DoctorCreateVM vm)
		{
			await _context.Doctors.AddAsync(new Doctor
			{
				FullName=vm.Name,
				Specialization=vm.Specialization,
				DepartmentId=vm.DepartmentId,
				ImageUrl=vm.DoctorImage

			});
			await _context.SaveChangesAsync();
			return false;
		}

		public async Task<bool> Delete(int? id)
		{
			var data = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id);
			if (data != null)
			{
				_context.Doctors.Remove(data);
				await _context.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<DoctorCreateVM> Get(int id)
		{
			var data = await _context.Doctors.FindAsync(id);
			DoctorCreateVM vm = new DoctorCreateVM
			{
				Name = data.FullName,
				DepartmentId = data.DepartmentId,
				Specialization=data.Specialization,
				DoctorImage = data.ImageUrl 
				
			};
			return vm;
		}

		public async Task<List<Doctor>> GetAllAsync()
		{
			return await _context.Doctors.Where(x => x.IsDeleted == false).Include(x => x.Department).ToListAsync();
		}

		public async Task<bool> UpdateAsync(int id, DoctorCreateVM vm)
		{
			var data = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id);
			if (data != null)
			{
				data.FullName = vm.Name;
				data.DepartmentId = vm.DepartmentId;
				data.Specialization = vm.Specialization;
				data.ImageUrl = vm.DoctorImage;
				await _context.SaveChangesAsync();
				return true;

			};
			return false;

		}
	}
}
