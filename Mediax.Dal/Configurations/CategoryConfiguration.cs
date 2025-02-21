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
   
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.Property(x => x.Name).IsRequired().HasMaxLength(100);


			builder.HasMany(x => x.Products)
				   .WithOne(x => x.Category)
				   .HasForeignKey(x => x.CategoryId)
				   .OnDelete(DeleteBehavior.Cascade);
		}
	}
}
