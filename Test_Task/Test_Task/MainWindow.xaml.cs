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

        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Menu.Width = this.Width;
            coinsList.AllowDrop = false;
            coinsList.CanUserSortColumns = false;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var client = new RestClient();
            var request = new RestRequest("https://api.coincap.io/v2/assets", Method.Get) { Timeout = -1 };
            var response = client.Execute(request);
            dynamic json_coins = JsonConvert.DeserializeObject(response.Content);
            foreach (var item in json_coins["data"])
            {
                coins.Add(JsonConvert.DeserializeObject<Coin>(JsonConvert.SerializeObject(item, Formatting.None)));
            }
            coinsList.ItemsSource = coins;
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Menu.Width = this.Width;
        }

        private void searchInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            coinsList.ItemsSource = coins.Where(p => p.Name.ToUpper().Contains(searchInput.Text.ToUpper()));
            if (!coinsList.HasItems)
                coinsList.Visibility = Visibility.Hidden;
            else
                coinsList.Visibility = Visibility.Visible;
        }

        private void button_Click_2(object sender, RoutedEventArgs e)
        {
            Details details = new Details();
            details.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            details.Show();
        }
    }
}
