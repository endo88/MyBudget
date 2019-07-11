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

        public void Save(BankAccount account)
        {
            if (account.BankAccountID == 0)
            {
                _context.BankAccounts.Add(account);
            }
            else
            {
                BankAccount dbEntry =
                    _context.BankAccounts
                        .FirstOrDefault(a => a.BankAccountID == account.BankAccountID);
                if (dbEntry != null)
                {
                    dbEntry.Active = account.Active;
                    dbEntry.Balance = account.Balance;
                    dbEntry.BankName = account.BankName;
                    dbEntry.DebitLimit = account.DebitLimit;
                }
            }

            _context.SaveChanges();
        }

        public BankAccount Delete(int bankAccountID)
        {
            BankAccount dbEntry =
                _context.BankAccounts
                    .FirstOrDefault(a => a.BankAccountID == bankAccountID);
            if (dbEntry != null)
            {
                _context.BankAccounts.Remove(dbEntry);
                _context.SaveChanges();
            }

            return dbEntry;
        }
    }
}
