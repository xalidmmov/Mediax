﻿using Mediax.Core.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.Core.Entites
{
	public class Contact:BaseEntity
	{
		
		public IEnumerable<Branch> Branches { get; set; }
	}
}
