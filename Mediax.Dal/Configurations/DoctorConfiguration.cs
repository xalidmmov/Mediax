using Mediax.Core.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.Dal.Configurations
{
	internal class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
	{
		public void Configure(EntityTypeBuilder<Doctor> builder)
		{
			builder.HasOne(x => x.Department)
				   .WithMany(x => x.Doctors)
				   .HasForeignKey(x => x.DepartmentId);
				   

			builder.Property(x => x.FullName).IsRequired().HasMaxLength(100);
			builder.Property(x => x.Specialization).IsRequired().HasMaxLength(100);
			builder.Property(x => x.ImageUrl).HasMaxLength(255);
		}
	}
		
}
