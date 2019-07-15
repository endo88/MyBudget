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
    public class IncomeController : Controller
    {
        private readonly IIncomeRepository _repository;

        public IncomeController(IIncomeRepository repository)
        {
            _repository = repository;
        }

        public ViewResult List()
        {
            IncomeViewModel incomes = new IncomeViewModel
            {
                Incomes = _repository.Incomes.OrderByDescending(i => i.Date)
            };
            return View(incomes);
        }

        public ViewResult Edit(int incomeID)
        {
            return View(_repository.Incomes.FirstOrDefault(i => i.IncomeID == incomeID));
        }

        [HttpPost]
        public IActionResult Edit(Income income)
        {
            if (ModelState.IsValid)
            {
                _repository.Save(income);
                return RedirectToAction(nameof(List));
            }

            return View(income);
        }

        [HttpPost]
        public IActionResult Delete(int incomeId)
        {
            _repository.Delete(incomeId);
            return RedirectToAction(nameof(List));
        }

        public ViewResult Add()
        {
            return View("Edit", new Income { Date = DateTime.Today });
        }

        [HttpPost]
        public IActionResult MarkAsReceived(int incomeId)
        {
            _repository.MarkAsReceived(incomeId);
            return RedirectToAction(nameof(List));
        }

    }
}
