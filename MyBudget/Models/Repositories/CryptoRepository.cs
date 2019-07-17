using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using MyBudget.Models.Abstractions;
using MyBudget.Models.DatabaseContexts;

namespace MyBudget.Models.Repositories
{
    public class CryptoRepository : ICryptoRepository
    {
        private readonly ApplicationDbContext _context;

        public CryptoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<CryptoCurrency> CryptoCurrencies { get; }
        public void Save(CryptoCurrency cryptoCurrency)
        {
            throw new NotImplementedException();
        }
    }
}
