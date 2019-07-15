using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace MyBudget.Models.Abstractions
{
    public interface IExpenseRepository
    {
        IQueryable<Expense> Expenses { get; }

        void Save(Expense expense);

        Expense Delete(int expenseId);

        Expense MarkAsPaid(int expenseId);
    }
}
