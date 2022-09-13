using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using Test_Task.Data;

namespace Test_Task.ViewModels
{
    public class DetailsViewModel
    {
        readonly Details details;
        List<MarketInfo> markets;

        public DetailsViewModel(Details details)
        {
            this.details = details;
            markets = new List<MarketInfo>();
        }

        public void CreateDisplayList()
        {
            string id = details.label.Content.ToString().SkipWhile(p => p != '/').ToArray().AsSpan().ToString();
            var client = new RestClient();
            var request = new RestRequest($"https://api.coincap.io/v2/assets/{id}/markets", Method.Get) { Timeout = -1 };
            var response = client.Execute(request);
            dynamic json_markets = JsonConvert.DeserializeObject(response.Content);
            foreach (var item in json_markets["data"])
            {
                markets.Add(new MarketInfo()
                {
                    ExchangeId = item.exchangeId != null ? item.exchangeId : "",
                    BaseId = item.baseId != null ? item.baseId : "",
                    QuoteId = item.quoteId != null ? item.quoteId : "",
                    BaseSymbol = item.baseSymbol != null ? item.baseSymbol : "",
                    QuoteSymbol = item.quoteSymbol != null ? item.quoteSymbol : "",
                    VolumeUsd24Hr = item.volumeUsd24Hr != null ? Math.Round(Convert.ToDouble(item.volumeUsd24Hr), 4) : 0,
                    PriceUsd = item.priceUsd != null ? Math.Round(Convert.ToDouble(item.priceUsd), 4) : 0
                });
            }
            details.dataGrid.ItemsSource = markets;
        }
    }
}