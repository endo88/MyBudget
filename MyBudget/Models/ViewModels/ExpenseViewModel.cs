using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBudget.Models.ViewModels
{
    public class ExpenseViewModel
    {
        public IEnumerable<Expense> Expenses { get; set; }

        public decimal CalculateLeftToPay() => Expenses.Where(e => !e.Paid).Sum(e => e.Amount);
    }
}
