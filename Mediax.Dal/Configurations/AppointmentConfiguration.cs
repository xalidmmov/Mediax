using Mediax.Dal.Migrations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mediax.Core.Entites;

namespace Mediax.Dal.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Apointment>
    {
        public void Configure(EntityTypeBuilder<Apointment> builder)
        {
            builder.Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.AppointmentDate)
                .IsRequired();

            builder.Property(x => x.Message)
                .HasMaxLength(500);
        }
    }
}