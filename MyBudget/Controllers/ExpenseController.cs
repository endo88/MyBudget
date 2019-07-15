using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyBudget.Models;
using MyBudget.Models.Abstractions;
using MyBudget.Models.ViewModels;

namespace MyBudget.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseRepository _repository;

        public ExpenseController(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public ViewResult List()
        {
            ExpenseViewModel accounts = new ExpenseViewModel
            {
                Expenses = _repository.Expenses.OrderByDescending(e => e.Date)
            };
            return View(accounts);
        }

        public ViewResult Edit(int expenseID)
        {
            return View(_repository.Expenses.FirstOrDefault(i => i.ExpenseID == expenseID));
        }

        [HttpPost]
        public IActionResult Edit(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _repository.Save(expense);
                return RedirectToAction(nameof(List));
            }

            return View(expense);
        }

        [HttpPost]
        public IActionResult Delete(int expenseId)
        {
            _repository.Delete(expenseId);
            return RedirectToAction(nameof(List));
        }

        public ViewResult Add()
        {
            return View("Edit", new Expense { Date = DateTime.Today });
        }

        [HttpPost]
        public IActionResult MarkAsPaid(int expenseId)
        {
            _repository.MarkAsPaid(expenseId);
            return RedirectToAction(nameof(List));
        }
    }
}
