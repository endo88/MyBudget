using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using MyBudget.Models;
using MyBudget.Models.Abstractions;
using MyBudget.Models.ViewModels;
using MyBudget.Views.Home;

namespace MyBudget.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBankAccountRepository _accountRepository;
        private readonly IExpenseRepository _expenseRepository;
        private readonly IIncomeRepository _incomeRepository;

        public HomeController(IBankAccountRepository accountRepository, IExpenseRepository expenseRepository, IIncomeRepository incomeRepository)
        {
            _accountRepository = accountRepository;
            _expenseRepository = expenseRepository;
            _incomeRepository = incomeRepository;
        }

        public ViewResult Index()
        {
            HomeViewModel hvm = new HomeViewModel
            {
                Accounts = _accountRepository.Accounts.OrderBy(a => a.BankName),
                Expenses = _expenseRepository.Expenses.OrderByDescending(e => e.Date),
                Incomes = _incomeRepository.Incomes.OrderByDescending(i => i.Date)
            };
            return View(hvm);
        }

        public ViewResult EditBankAccount(int BankAccountID)
        {
            return View(_accountRepository.Accounts.FirstOrDefault(a => a.BankAccountID == BankAccountID));
        }

        public ViewResult AddBankAccount()
        {
            return View("EditBankAccount", new BankAccount());
        }

        [HttpPost]
        public IActionResult EditBankAccount(BankAccount account)
        {
            if (ModelState.IsValid)
            {
                _accountRepository.Save(account);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(account);
            }

        }

        [HttpPost]
        public IActionResult DeleteBankAccount(int bankAccountID)
        {
            _accountRepository.Delete(bankAccountID);
            return RedirectToAction("Index");
        }

        public ViewResult EditIncome(int incomeID)
        {
            return View(_incomeRepository.Incomes.FirstOrDefault(i => i.IncomeID == incomeID));
        }

        [HttpPost]
        public IActionResult EditIncome(Income income)
        {
            if (ModelState.IsValid)
            {
                _incomeRepository.Save(income);
                return RedirectToAction(nameof(Index));
            }

            return View(income);
        }

        [HttpPost]
        public IActionResult DeleteIncome(int incomeId)
        {
            _incomeRepository.Delete(incomeId);
            return RedirectToAction(nameof(Index));
        }

        public ViewResult AddIncome()
        {
            return View("EditIncome", new Income{Date = DateTime.Today});
        }


        public ViewResult EditExpense(int expenseID)
        {
            return View(_expenseRepository.Expenses.FirstOrDefault(i => i.ExpenseID == expenseID));
        }

        [HttpPost]
        public IActionResult EditExpense(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _expenseRepository.Save(expense);
                return RedirectToAction(nameof(Index));
            }

            return View(expense);
        }

        [HttpPost]
        public IActionResult DeleteExpense(int expenseId)
        {
            _expenseRepository.Delete(expenseId);
            return RedirectToAction(nameof(Index));
        }

        public ViewResult AddExpense()
        {
            return View("EditExpense", new Expense { Date = DateTime.Today });
        }
    }
}
