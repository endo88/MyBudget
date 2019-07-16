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
    public class BankAccountController : Controller
    {
        private readonly IBankAccountRepository _repository;

        public BankAccountController(IBankAccountRepository repository)
        {
            _repository = repository;
        }

        public ViewResult List()
        {
            BankAccountViewModel accounts = new BankAccountViewModel
            {
                Accounts = _repository.Accounts.OrderBy(a => a.BankName)
            };
            return View(accounts);
        }

        public ViewResult Edit(int BankAccountID)
        {
            return View(_repository.Accounts.FirstOrDefault(a => a.BankAccountID == BankAccountID));
        }

        public ViewResult Add()
        {
            return View("Edit", new BankAccount());
        }

        [HttpPost]
        public IActionResult Edit(BankAccount account)
        {
            if (ModelState.IsValid)
            {
                _repository.Save(account);
                return RedirectToAction(nameof(List));
            }
            else
            {
                return View(account);
            }

        }

        [HttpPost]
        public IActionResult Delete(int bankAccountID)
        {
            _repository.Delete(bankAccountID);
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult MarkAsActive(int bankAccountID)
        {
            _repository.MarkAsActive(bankAccountID);
            return RedirectToAction(nameof(List));
        }
    }
}
