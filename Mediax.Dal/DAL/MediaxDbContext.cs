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
	public class MediaxDbContext : IdentityDbContext<User>
	{
		
		public DbSet<Service> Services { get; set; }
		public DbSet<Doctor> Doctors { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<AboutFeature> AboutFeatures { get; set; }
		public MediaxDbContext(DbContextOptions options) : base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(MediaxDbContext).Assembly);
			base.OnModelCreating(modelBuilder);

		}
	}
}
