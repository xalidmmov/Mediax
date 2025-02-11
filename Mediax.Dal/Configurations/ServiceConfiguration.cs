using Mediax.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.Dal.Configurations
{


	public class ServiceConfiguration:IEntityTypeConfiguration<Service>
	{
		public void Configure(EntityTypeBuilder<Service> builder)
		{
			builder.HasOne(x => x.Department)
				   .WithMany(x => x.Services)
				   .HasForeignKey(x => x.DepartmentId);


			builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
			builder.Property(x => x.IconUrl).HasMaxLength(255);
		}
	}
	
	
}
