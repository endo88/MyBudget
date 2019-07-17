using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyBudget.Models
{
    public class CryptoCurrency
    {
        [JsonProperty(PropertyName = "Coin_Id")]
        public string CoinID { get; set; }
        public List<ExchangeDetail> Prices { get; set; }
    }

    public class ExchangeDetail
    {
        [JsonProperty(PropertyName = "Id_currency")]
        public string CurrencyID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
