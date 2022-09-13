using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Test_Task.Data;

namespace Test_Task
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : Window
    {

        List<MarketInfo> markets = new List<MarketInfo>();
        public Details()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            LoadList();
        }
        private void LoadList()
        {
            string id = label.Content.ToString().SkipWhile(p => p != '/').ToArray().AsSpan().ToString();
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
            dataGrid.ItemsSource = markets;
        }
    }
}
