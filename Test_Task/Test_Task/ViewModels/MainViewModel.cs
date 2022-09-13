using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Test_Task.ViewModels
{
    public class MainViewModel
    {
        readonly MainWindow mainWindow;
        List<Coin> coins;
        List<object> displayingCoins;

        public MainViewModel(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            coins = new List<Coin>();
            displayingCoins = new List<object>();
        }

        public List<Coin> Coins { get { return coins; } }

        public void CreateList()
        {
            var client = new RestClient();
            var request = new RestRequest("https://api.coincap.io/v2/assets", Method.Get) { Timeout = -1 };
            var response = client.Execute(request);
            dynamic json_coins = JsonConvert.DeserializeObject(response.Content);
            foreach (var item in json_coins["data"])
            {
                coins.Add(new Coin()
                {
                    Id = item.id != null ? item.id : "",
                    Rank = item.rank != null ? item.rank : "",
                    Symbol = item.symbol != null ? item.symbol : "",
                    Name = item.name != null ? item.name : "",
                    Supply = item.supply != null ? Math.Round(Convert.ToDouble(item.supply), 4) : 0,
                    MaxSupply = item.maxSupply != null ? Math.Round(Convert.ToDouble(item.maxSupply), 4) : 0,
                    MarketCapUsd = item.marketCapUsd != null ? Math.Round(Convert.ToDouble(item.marketCapUsd), 4) : 0,
                    VolumeUsd24Hr = item.volumeUsd24Hr != null ? Math.Round(Convert.ToDouble(item.volumeUsd24Hr), 4) : 0,
                    PriceUsd = item.priceUsd != null ? Math.Round(Convert.ToDouble(item.priceUsd), 4) : 0,
                    ChangePercent24Hr = item.changePercent24Hr != null ? Math.Round(Convert.ToDouble(item.changePercent24Hr), 4) : 0,
                    Vwap24Hr = item.vwap24Hr != null ? Math.Round(Convert.ToDouble(item.vwap24Hr), 4) : 0
                });
            }
        }

        public void DisplayCoins()
        {
            displayingCoins.Clear();
            displayingCoins.AddRange(coins.Select(p => new { p.Id, p.Name, p.Symbol, p.Rank, p.PriceUsd }).ToList());
            mainWindow.coinsList.ItemsSource = displayingCoins;
        }

        public void FindCoin()
        {
            mainWindow.coinsList.ItemsSource = null;
            displayingCoins.Clear();
            displayingCoins.AddRange(coins.Where(p => p.Name.ToUpper().Contains(mainWindow.searchInput.Text.ToUpper())).Select(p => new { p.Id, p.Name, p.Symbol, p.Rank, p.PriceUsd }).ToList());
            mainWindow.coinsList.ItemsSource = displayingCoins;
            if (!mainWindow.coinsList.HasItems)
                mainWindow.coinsList.Visibility = Visibility.Hidden;
            else
                mainWindow.coinsList.Visibility = Visibility.Visible;
        }

        public void ShowExchange()
        {
            Exchange exchange = new Exchange(coins);
            exchange.Show();
        }

        public void ShowDetails()
        {
            Details details = new Details();
            details.label.Content = $"Currencies/{mainWindow.coinsList.CurrentItem.ToString().SkipWhile(p => p != '=').Skip(2).TakeWhile(p => p != ',').ToArray().AsSpan()}";
            details.Show();
        }
    }
}
