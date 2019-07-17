using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBudget.Models.Abstractions
{
    public interface ICryptoRepository
    {
        IQueryable<CryptoCurrency> CryptoCurrencies { get; }

        void Save(CryptoCurrency cryptoCurrency);
    }
}
