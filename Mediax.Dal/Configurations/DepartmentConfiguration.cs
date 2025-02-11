﻿using Mediax.Core.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.Dal.Configurations
{
	internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
	{
		public void Configure(EntityTypeBuilder<Department> builder)
		{
			builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

			
			builder.HasMany(x => x.Services)
				   .WithOne(x => x.Department)
				   .HasForeignKey(x => x.DepartmentId);
				  

			
			builder.HasMany(x => x.Doctors)
				   .WithOne(x => x.Department)
				   .HasForeignKey(x => x.DepartmentId);
				   
		}
	}
	

}
