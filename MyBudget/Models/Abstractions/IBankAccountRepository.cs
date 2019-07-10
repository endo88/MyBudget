using System.Linq;

namespace MyBudget.Models.Abstractions
{
    public interface IBankAccountRepository
    {
        IQueryable<BankAccount> Accounts { get; }

        void SaveBankAccount(BankAccount account);
    }
}