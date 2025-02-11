using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL.ViewModels.Department
{
	public class DepartmentCreateVM
	{
		[Required, MaxLength(32)]
		public string Name { get; set; } = null!;
	}
}
