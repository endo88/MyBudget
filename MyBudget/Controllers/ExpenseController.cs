using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyBudget.Models;
using MyBudget.Models.Abstractions;
using MyBudget.Models.ViewModels;

namespace MyBudget.Controllers
{
    [Authorize]
    public class ExpenseController : Controller
    {
        private readonly IExpenseRepository _repository;

        public ExpenseController(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public ViewResult List(string sortOrder, string searchString)
        {
            ExpenseViewModel accounts = new ExpenseViewModel
            {
                Expenses = _repository.Expenses
            };

            if (!string.IsNullOrEmpty(searchString))
            {
                accounts.Expenses = accounts.Expenses.Where(e => e.Description.Contains(searchString));
            }

            ViewBag.DateSortParam = string.IsNullOrEmpty(sortOrder) || !sortOrder.Contains("desc") ? "Date_desc" : "Date";
            ViewBag.TypeSortParam = sortOrder == "Type" ? "Type_desc" : "Type";
            ViewBag.AmountSortParam = sortOrder == "Amount" ? "Amount_desc" : "Amount";

            switch (sortOrder)
            {
                case "Type":
                    accounts.Expenses = accounts.Expenses.OrderBy(e => e.Type);
                    break;
                case "Type_desc":
                    accounts.Expenses = accounts.Expenses.OrderByDescending(e => e.Type);
                    break;
                case "Amount":
                    accounts.Expenses = accounts.Expenses.OrderBy(e => e.Amount);
                    break;
                case "Amount_desc":
                    accounts.Expenses = accounts.Expenses.OrderByDescending(e => e.Amount);
                    break;
                case "Date":
                    accounts.Expenses = accounts.Expenses.OrderBy(e => e.Date);
                    break;
                case "Date_desc":
                    accounts.Expenses = accounts.Expenses.OrderByDescending(e => e.Date);
                    break;
                default:
                    accounts.Expenses = accounts.Expenses.OrderBy(e => e.ExpenseID);
                    break;
            }

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
