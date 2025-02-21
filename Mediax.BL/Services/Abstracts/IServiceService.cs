using Mediax.BL.ViewModels.Doctor;
using Mediax.BL.ViewModels.Service;
using Mediax.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL.Services.Abstracts
{
	public interface IServiceService
	{
		Task<List<Service>> GetAllAsync();
		Task<bool> Create(ServiceCreateVM vm);
		Task<bool> Delete(int? id);
		Task<bool> UpdateAsync(int id, ServiceCreateVM vm);
		Task<ServiceCreateVM> Get(int id);
	}
}
