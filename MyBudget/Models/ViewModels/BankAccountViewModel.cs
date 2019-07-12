using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBudget.Models.ViewModels
{
    public class BankAccountViewModel
    {
        public IEnumerable<BankAccount> Accounts { get; set; }

        public decimal CalculateTotalBalance() =>
            Accounts.Where(a => a.Active).Sum(a => (a.Balance - a.DebitLimit));
    }
}
