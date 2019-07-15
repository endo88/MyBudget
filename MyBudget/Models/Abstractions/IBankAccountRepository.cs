using System.Linq;

namespace MyBudget.Models.Abstractions
{
    public interface IBankAccountRepository
    {
        IQueryable<BankAccount> Accounts { get; }

        void Save(BankAccount account);

        BankAccount Delete(int bankAccountID);

        BankAccount MarkAsActive(int bankAccountID);
    }
}