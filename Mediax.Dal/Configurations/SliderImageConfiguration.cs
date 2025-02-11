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
	internal class SliderImageConfiguration : IEntityTypeConfiguration<SliderImage>
	{
		public void Configure(EntityTypeBuilder<SliderImage> builder)
		{
			builder.Property(x => x.ImageUrl).HasMaxLength(255);

			
			builder.HasOne<PageSlider>()
				   .WithMany(x => x.Images)
				   .HasForeignKey(x => x.PageSliderId);
				   
		}
	}
	
	
}
