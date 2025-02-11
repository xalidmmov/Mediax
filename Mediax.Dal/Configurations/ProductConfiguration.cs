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
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasOne(x => x.Category)
				   .WithMany(x => x.Products)
				   .HasForeignKey(x => x.CategoryId);
				  

			builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
			builder.Property(x => x.Description).HasMaxLength(500);
			builder.Property(x => x.CostPrice).IsRequired().HasColumnType("decimal(18,2)");
			builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
			builder.Property(x => x.DiscountPrice).HasColumnType("decimal(18,2)");
			builder.Property(x => x.ImageUrl).HasMaxLength(255);
		}
	}


}
