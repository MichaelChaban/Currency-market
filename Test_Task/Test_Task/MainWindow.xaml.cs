using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace Test_Task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow  : Window
    {
        List<Coin> coins = new List<Coin>();
        List<Object> displayingCoins = new List<Object>();

        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            LoadList();
            displayingCoins.Clear();
            displayingCoins.AddRange(coins.Select(p => new { p.Id, p.Name, p.Symbol,p.Rank, p.PriceUsd}).ToList());
            coinsList.ItemsSource = displayingCoins;
        }

        private void searchInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            ClearAll();
            displayingCoins.AddRange(coins.Where(p => p.Name.ToUpper().Contains(searchInput.Text.ToUpper())).Select(p => new { p.Id, p.Name, p.Symbol, p.Rank, p.PriceUsd }).ToList());
            coinsList.ItemsSource = displayingCoins;
            if (!coinsList.HasItems)
                coinsList.Visibility = Visibility.Hidden;
            else
                coinsList.Visibility = Visibility.Visible;
        }

        private void button_Click_2(object sender, RoutedEventArgs e)
        {
            
        }
        private void LoadList()
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
        private void ClearAll()
        {
            coinsList.ItemsSource = null;
            displayingCoins.Clear();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Details details = new Details();
            details.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            details.label.Content = $"Currencies/{coinsList.CurrentItem.ToString().SkipWhile(p => p != '=').Skip(2).TakeWhile(p => p != ',').ToArray().AsSpan()}";
            details.Show();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            menu.MaxWidth = this.Width;
            coinsList.MaxHeight = this.Height * 2 / 3;
        }

        private void exchange_Click(object sender, RoutedEventArgs e)
        {
            Exchange exchange = new Exchange(coins);
            exchange.Show();
        }
        public List<Coin> GetList()
        {
            return coins;
        }
    }
}
