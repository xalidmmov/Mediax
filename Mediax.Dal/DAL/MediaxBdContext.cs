using Mediax.Core.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.Dal.DAL
{
	public class MediaxBdContext : IdentityDbContext<User>
	{
		public DbSet<PageSlider> PageSliders { get; set; }
		public DbSet<SliderImage> SliderImages { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<Doctor> Doctors { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		
		public MediaxBdContext(DbContextOptions options) : base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(MediaxBdContext).Assembly);
			base.OnModelCreating(modelBuilder);

		}
	}
}
