using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyBudget.Models
{
    public class Expense
    {
        public int ExpenseID { get; set; }

        [Required(ErrorMessage = "Please provide a type of Expense")]
        public string Type { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Amount needs to be positive")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Please provide a description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please provide date of expense")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please specify if the expense was already received")]
        public bool Paid { get; set; }
    }
}
