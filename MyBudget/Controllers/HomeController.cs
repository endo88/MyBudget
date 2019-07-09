﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using MyBudget.Models.Abstractions;
using MyBudget.Models.ViewModels;

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
                Accounts = _accountRepository.Accounts,
                Expenses = _expenseRepository.Expenses,
                Incomes = _incomeRepository.Incomes
            };
            return View(hvm);
        }
    }
}
