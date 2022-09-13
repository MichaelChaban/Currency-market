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

namespace Test_Task
{
    /// <summary>
    /// Interaction logic for Exchange.xaml
    /// </summary>
    public partial class Exchange : Window
    {
        List<Coin> coins;
        public Exchange(List<Coin> coins)
        {
            InitializeComponent();
            this.coins = coins;
        }

        private void convert_TextChanged(object sender, TextChangedEventArgs e)
        {
            double result = Convertation();
            if (result > 0)
                convertIn.Content = result.ToString();
        }
        private double Convertation()
        {
            double amount = 1, result = 0;
            try
            {
                amount = Convert.ToDouble(convert.Text);
            }
            catch
            {
                convertIn.Content = "Wrong Data";
            }
            try
            {
                if(amount > 0)
                    result = Math.Round(amount * coins.Where(p => p.Symbol == conversionList.SelectedItem).Select(p => p.PriceUsd).First() / coins.Where(p => p.Symbol == conversionInList.SelectedItem).Select(p => p.PriceUsd).First(), 4);
            }
            catch
            {
                convertIn.Content = "Choose currencies";
            }
            return result;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = coins.Select(p => new { p.Name, p.Symbol, p.PriceUsd}).ToList();
            conversionList.ItemsSource = coins.Select(p => p.Symbol).ToList();
            conversionInList.ItemsSource = coins.Select(p => p.Symbol).ToList();
        }

        private void convertBtn_Click(object sender, RoutedEventArgs e)
        {
            double result = Convertation();
            if (result > 0)
                convertIn.Content = result.ToString();
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
