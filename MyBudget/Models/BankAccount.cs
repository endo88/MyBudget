using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MyBudget.Models
{
    public class BankAccount
    {
        public int BankAccountID { get; set; }
        [Required(ErrorMessage = "Please provide the Bank name")]
        public string BankName { get; set; }
        [Required(ErrorMessage = "Please provide balance")]
        public decimal Balance { get; set; }
        [Required]
        [Range(0,int.MaxValue,ErrorMessage = "Debit Limit needs to be a positive value")]
        public decimal DebitLimit { get; set; }
        [Required(ErrorMessage = "Please specify whether the account is active or not")]
        public bool Active { get; set; }
    }
}
