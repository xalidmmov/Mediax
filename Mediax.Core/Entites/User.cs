﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.Core.Entites
{
	public class User:IdentityUser
	{
        public string  FullName { get; set; }
		public string ProfileImageUrl { get; set; }
	}
}
