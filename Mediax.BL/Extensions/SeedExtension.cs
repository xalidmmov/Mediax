using Mediax.Core.Entites;
using Mediax.Core.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL.Extensions
{
	public static class SeedExtension
	{
        public static async void UseUserSeed(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if (!roleManager.Roles.Any())
                {
                    foreach (Roles role in Enum.GetValues(typeof(Roles)))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role.ToString()));
                    }
                }
                if (!userManager.Users.Any(x => x.NormalizedUserName == "ADMIN"))
                {
                    User Admin = new User
                    {
                        FullName = "Admin",
                        UserName = "Admin",
                        Email = "admin@gmail.com",

                    };
                    await userManager.CreateAsync(Admin, "Admin123.");
                    await userManager.AddToRoleAsync(Admin, Roles.Admin.ToString());

                }
            }
        }
    }
}
