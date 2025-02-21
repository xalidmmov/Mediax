using Mediax.BL.ViewModels.Doctor;
using Mediax.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mediax.BL.Services.Abstracts
{
	public interface IDoctorService
	{
		Task<List<Doctor>> GetAllAsync();
		Task<bool> Create(DoctorCreateVM vm);
		Task<bool> Delete(int? id);
		Task<bool> UpdateAsync(int id, DoctorCreateVM vm);
		Task<DoctorCreateVM> Get(int id);
	}
}
