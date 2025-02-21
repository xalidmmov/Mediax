﻿using Mediax.Core.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.Core.Entites
{
	public class Doctor:BaseEntity
	{
		public string FullName { get; set; }
		public string Specialization { get; set; }
		public string ImageUrl { get; set; } 
		public int DepartmentId { get; set; }  
		public Department Department { get; set; }
	}
}
