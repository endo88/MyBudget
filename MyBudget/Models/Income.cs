using System;
using System.Security.AccessControl;


namespace MyBudget.Models
{
    public class Income
    {
        public int IncomeID { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public bool Received { get; set; }
    }
}
