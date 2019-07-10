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

        public decimal CalculateLeftToPay() => Expenses.Where(e => !e.Paid).Sum(e => e.Amount);

        public decimal CalculateLeftToReceive() => Incomes.Where(i => !i.Received).Sum(i => i.Amount);

        public decimal CalculateTotalBalance() =>
            Accounts.Where(a => a.Active).Sum(a => (a.Balance - a.DebitLimit));

        public decimal CalculateLeftToSpend() => CalculateTotalBalance() - CalculateLeftToPay();

    }
}
