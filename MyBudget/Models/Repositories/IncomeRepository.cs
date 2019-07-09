using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
