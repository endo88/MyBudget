using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBudget.Models.ViewModels
{
    public class IncomeViewModel
    {
        public IEnumerable<Income> Incomes { get; set; }

        public decimal CalculateLeftToReceive() => Incomes.Where(i => !i.Received).Sum(i => i.Amount);
    }
}
