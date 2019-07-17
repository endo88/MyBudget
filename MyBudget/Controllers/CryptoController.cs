using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBudget.Models;
using Newtonsoft.Json;
using unirest_net.http;

namespace MyBudget.Controllers
{
    public class CryptoController : Controller
    {
        private List<CryptoCurrency> currencies;

        private List<string> coinIDs;

        public CryptoController()
        {
            currencies = new List<CryptoCurrency>();
            coinIDs = new List<string>
            {
                "btc",
                "ltc",
                "eth",
                "xrp",
                "bch"
            };
        }

        public ViewResult List()
        {
            foreach (var Id in coinIDs)
            {
                var response = GetCurrencyRatesByCoinId(Id);

                ParseBody(response.Body);
            }

            return View("List",currencies);
        }

        private void ParseBody(string responseBody)
        {
            var body = JsonConvert.DeserializeObject<CryptoCurrency>(responseBody);

            body.Prices = body.Prices.Where(p => p.CurrencyID == "USD").ToList();

            currencies.Add(body);
        }

        private HttpResponse<string> GetCurrencyRatesByCoinId(string coinId)
        {
            var url = $"https://bravenewcoin-v1.p.rapidapi.com/prices?coin={coinId}";
            HttpResponse<string> response = Unirest.get(url)
                .header("X-RapidAPI-Host", "bravenewcoin-v1.p.rapidapi.com")
                .header("X-RapidAPI-Key", "4114f32b36mshed4ee80973c502fp17b8cejsna4d766f940ef")
                .asJson<string>();

            return response;
        }
    }
}
