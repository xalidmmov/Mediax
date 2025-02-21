using Mediax.BL;
using Mediax.Core.Entites;
using Mediax.Dal.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Mediax.MVC
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services
				.AddDbContext<MediaxDbContext>(options =>
				{
					options.UseSqlServer(builder.Configuration.GetConnectionString("MSSql"));
				});

			builder.Services.AddIdentity<User, IdentityRole>()
			  .AddDefaultTokenProviders()
			  .AddEntityFrameworkStores<MediaxDbContext>();
			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddServices();
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();
            app.MapControllerRoute(
              name: "areas",
              pattern: "{area:exists}/{controller=Dashboard}/{action=index}/{id?}"
              );
            app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
