using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SnowboardShop.Data;
using SnowboardShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnowboardShop
{
    public static class DataInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            // CREATING ROLES

            string[] roles = new string[] { "Admin", "User" };

            RoleManager<IdentityRole> roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            foreach (string role in roles)
            {

                if (!roleManager.Roles.Any(r => r.Name == role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // CREATE THE ADMIN USER

            var user = new ApplicationUser
            {
                UserName = "admin@admin.com",
                NormalizedUserName = "admin@admin.com",
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            UserManager<ApplicationUser> userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();


            if (!userManager.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "admin");
                user.PasswordHash = hashed;
                await userManager.CreateAsync(user);
                ApplicationUser admin = await userManager.FindByEmailAsync(user.Email);
                var result = userManager.AddToRolesAsync(admin, roles);
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }

    }
}
