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
	internal class PageSliderConfiguration : IEntityTypeConfiguration<PageSlider>
	{
		public void Configure(EntityTypeBuilder<PageSlider> builder)
		{
			builder.HasMany(x => x.Images)
				   .WithOne()
				   .HasForeignKey(x => x.PageSliderId);
				   
		}
	}
	
	 
}
