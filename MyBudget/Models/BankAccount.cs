using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBudget.Models
{
    public class BankAccount
    {
        public int BankAccountID { get; set; }
        public string BankName { get; set; }
        public decimal Balance { get; set; }
        public decimal DebitLimit { get; set; }
        public bool Active { get; set; }
    }
}
