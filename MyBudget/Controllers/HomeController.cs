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

        [HttpPost]
        public IActionResult EditBankAccount(BankAccount account)
        {
            if (ModelState.IsValid)
            {
                _accountRepository.SaveBankAccount(account);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(account);
            }

        }
    }
}
