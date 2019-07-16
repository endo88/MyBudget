using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyBudget.Models.DatabaseContexts;

namespace MyBudget.Infrastructure
{
    public  class SeedIdentityData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";

        private const string standardUser = "User";
        private const string userPassword = "Secret123$";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app
                .ApplicationServices
                .GetRequiredService<ApplicationIdentityDbContext>();

            context.Database.Migrate();

            UserManager<IdentityUser> manager = app.ApplicationServices
                .GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser admin = await manager.FindByIdAsync(adminUser);
            if (admin == null)
            {
                admin = new IdentityUser("Admin");
                await manager.CreateAsync(admin, adminPassword);
            }

            IdentityUser user = await manager.FindByIdAsync(standardUser);
            if (user == null)
            {
                user = new IdentityUser("User");
                await manager.CreateAsync(user, userPassword);
            }
        }
    }
}
