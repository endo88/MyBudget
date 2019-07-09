using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyBudget.Models;
using MyBudget.Models.DatabaseContexts;

namespace MyBudget.Infrastructure
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app
                .ApplicationServices
                .GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();

            if (!context.BankAccounts.Any())
            {
                context.BankAccounts.AddRange(
                    new BankAccount
                    {
                        Balance = 1000,
                        BankName = "PKO",
                        DebitLimit = 1000,
                        Active = true
                    },
                    new BankAccount
                    {
                        BankName = "Alior",
                        Balance = 2345,
                        DebitLimit = 3000,
                        Active =  true
                    },
                    new BankAccount
                    {
                        BankName = "Pekao",
                        Balance = 5000,
                        DebitLimit = 0,
                        Active = false
                    });
            }

            if (!context.Incomes.Any())
            {
                context.Incomes.AddRange(
                    new Income
                    {
                        Type = "Salary",
                        Amount = 5000,
                        Date = new DateTime(2019,3,1),
                        Received = true
                    },
                    new Income
                    {
                        Type = "Salary",
                        Amount = 8000,
                        Date = new DateTime(2019, 4, 1),
                        Received = true
                    },
                    new Income
                    {
                        Type = "Salary",
                        Amount = 3000,
                        Date = new DateTime(2019, 5, 1),
                        Received = true
                    },
                    new Income
                    {
                        Type = "Salary",
                        Amount = 10000,
                        Date = new DateTime(2019, 6, 1),
                        Received = true
                    },
                    new Income
                    {
                        Type = "Salary",
                        Amount = 6400,
                        Date = new DateTime(2019, 7, 1),
                        Received = true
                    },
                    new Income
                    {
                        Type = "Salary",
                        Amount = 4700,
                        Date = new DateTime(2019, 8, 1),
                        Received = false
                    });
            }

            if (!context.Expenses.Any())
            {
                context.AddRange(
                    new Expense
                    {
                        Type = "Housing",
                        Amount = 500,
                        Date = new DateTime(2019,3,1),
                        Paid = true
                    },
                    new Expense
                    {
                        Type = "Tv",
                        Amount = 100,
                        Date = new DateTime(2019, 3, 1),
                        Paid = true
                    },
                    new Expense
                    {
                        Type = "Petrol",
                        Amount = 1000,
                        Date = new DateTime(2019, 3, 1),
                        Paid = true
                    },
                    new Expense
                    {
                        Type = "Housing",
                        Amount = 700,
                        Date = new DateTime(2019, 4, 1),
                        Paid = true
                    },
                    new Expense
                    {
                        Type = "Tv",
                        Amount = 200,
                        Date = new DateTime(2019, 4, 1),
                        Paid = true
                    },
                    new Expense
                    {
                        Type = "Petrol",
                        Amount = 900,
                        Date = new DateTime(2019, 4, 1),
                        Paid = true
                    },
                    new Expense
                    {
                        Type = "Housing",
                        Amount = 570,
                        Date = new DateTime(2019, 8, 1),
                        Paid = false
                    },
                    new Expense
                    {
                        Type = "Tv",
                        Amount = 149,
                        Date = new DateTime(2019, 8, 1),
                        Paid = false
                    },
                    new Expense
                    {
                        Type = "Petrol",
                        Amount = 431,
                        Date = new DateTime(2019, 8, 1),
                        Paid = false
                    });
            }

            context.SaveChanges();
        }
    }
}
