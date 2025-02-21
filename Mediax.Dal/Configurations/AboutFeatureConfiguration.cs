using Mediax.Core.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.Dal.Configurations
{
    public class AboutFeatureConfiguration
    {
        public void Configure(EntityTypeBuilder<AboutFeature> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.IconUrl).HasMaxLength(250);
        }
    }
}
