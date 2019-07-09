using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBudget.Models.Abstractions;
using MyBudget.Models.DatabaseContexts;

namespace MyBudget.Models.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public BankAccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<BankAccount> Accounts => _context.BankAccounts;
    }
}
