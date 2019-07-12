using System;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;


namespace MyBudget.Models
{
    public class Income
    {
        public int IncomeID { get; set; }
        [Required(ErrorMessage = "Please provide a type of Income")]
        public string Type { get; set; }
        [Required]
        [Range(0,int.MaxValue, ErrorMessage = "Amount needs to be positive")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "Please provide date of income")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please specify if the income was already received")]
        public bool Received { get; set; }
    }
}
