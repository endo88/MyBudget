using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBudget.Models.Abstractions;
using MyBudget.Models.DatabaseContexts;

namespace MyBudget.Models.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExpenseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Expense> Expenses => _context.Expenses;

        public void Save(Expense expense)
        {
            if (expense.ExpenseID == 0)
            {
                _context.Expenses.Add(expense);
            }
            else
            {
                Expense dbEntry = _context.Expenses
                    .FirstOrDefault(e => e.ExpenseID == expense.ExpenseID);

                if (dbEntry != null)
                {
                    dbEntry.Type = expense.Type;
                    dbEntry.Amount = expense.Amount;
                    dbEntry.Date = expense.Date;
                    dbEntry.Paid = expense.Paid;
                    dbEntry.Description = expense.Description;
                }
            }

            _context.SaveChanges();
        }

        public Expense Delete(int expenseId)
        {
            Expense dbEntry = _context.Expenses
                .FirstOrDefault(e => e.ExpenseID == expenseId);

            if (dbEntry != null)
            {
                _context.Remove(dbEntry);
                _context.SaveChanges();
            }

            return dbEntry;
        }

        public Expense MarkAsPaid(int expenseId)
        {
            Expense dbEntry = _context.Expenses
                .FirstOrDefault(e => e.ExpenseID == expenseId);

            if (dbEntry != null)
            {
                dbEntry.Paid = !dbEntry.Paid;
                _context.SaveChanges();
            }

            return dbEntry;
        }
    }
}
