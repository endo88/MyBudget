using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBudget.Infrastructure;
using MyBudget.Models.Abstractions;
using MyBudget.Models.DatabaseContexts;
using MyBudget.Models.Repositories;

namespace MyBudget
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("LocalDb")));

            services.AddTransient<IBankAccountRepository, BankAccountRepository>();
            services.AddTransient<IExpenseRepository, ExpenseRepository>();
            services.AddTransient<IIncomeRepository, IncomeRepository>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            SeedData.EnsurePopulated(app);
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();

        }
    }
}
