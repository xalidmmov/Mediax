using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL.ViewModels.Service
{
	public class ServiceCreateVM
	{
		[Required, MaxLength(32)]
		public string SName { get; set; }
        public Guid DepartmentId { get; set; }
        public IFormFile? CoverSImage { get; set; }
		public string? ServiceImg { get; set; }
	}
}
