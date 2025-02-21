using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL.ViewModels.Doctor
{
	public class DoctorCreateVM
	{
		[Required, MaxLength(32)]
		public string Name { get; set; }
		[MaxLength(32)]
		public string? Specialization { get; set; }

		public int DepartmentId { get; set; }
		public IFormFile? CoverImage { get; set; }
		public string? DoctorImage { get; set; }
	}
}
