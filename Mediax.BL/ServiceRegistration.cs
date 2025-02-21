using Mediax.BL.Services.Abstracts;
using Mediax.BL.Services.Implements;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL
{
	public static class ServiceRegistration
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<IDepartmentService, DepartmentService>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<IDoctorService, DoctorService>();
			services.AddScoped<IServiceService, ServiceService>();
			services.AddScoped<IProductService, ProductService>();
			return services;
		}
	}
}
