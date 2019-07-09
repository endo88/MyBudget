using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBudget.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<BankAccount> Accounts { get; set; }
        public IEnumerable<Income> Incomes { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }
    }
}
