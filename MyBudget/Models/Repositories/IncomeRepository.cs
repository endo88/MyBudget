using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyBudget.Models.Abstractions;
using MyBudget.Models.DatabaseContexts;

namespace MyBudget.Models.Repositories
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly ApplicationDbContext _context;

        public IncomeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Income> Incomes => _context.Incomes;

        public void Save(Income income)
        {
            if (income.IncomeID == 0)
            {
                _context.Incomes.Add(income);
            }
            else
            {
                Income dbEntry = _context.Incomes
                    .FirstOrDefault(i => i.IncomeID == income.IncomeID);
                if (dbEntry != null)
                {
                    dbEntry.Amount = income.Amount;
                    dbEntry.Date = income.Date;
                    dbEntry.Type = income.Type;
                    dbEntry.Received = income.Received;
                }
            }

            _context.SaveChanges();
        }

        public Income Delete(int incomeID)
        {
            Income dbEntry = _context.Incomes
                .FirstOrDefault(i => i.IncomeID == incomeID);

            if (dbEntry != null)
            {
                _context.Incomes.Remove(dbEntry);
                _context.SaveChanges();
            }

            return dbEntry;
        }
    }
}
