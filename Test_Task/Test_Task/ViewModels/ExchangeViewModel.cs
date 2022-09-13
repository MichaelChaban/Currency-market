using System;
using System.Collections.Generic;
using System.Linq;

namespace Test_Task.ViewModels
{
    /// <summary>
    /// ViewModel for view Exchange
    /// </summary>
    
    public class ExchangeViewModel
    {
        readonly Exchange exchange;
        List<Coin> coins;

        public ExchangeViewModel(Exchange exchange, List<Coin> coins)
        {
            this.exchange = exchange;
            this.coins = coins;
        }

        public void DisplayData()
        {
            exchange.dataGrid.ItemsSource = coins.Select(p => new { p.Name, p.Symbol, p.PriceUsd }).ToList();
            exchange.conversionList.ItemsSource = coins.Select(p => p.Symbol).ToList();
            exchange.conversionInList.ItemsSource = coins.Select(p => p.Symbol).ToList();
        }

        public void ClickTypeConvert()
        {
            double result = ToConvert();
            if (result > 0)
                exchange.convertIn.Content = result.ToString();
        }
        private double ToConvert()
        {
            double amount = 1, result = 0;
            try
            {
                amount = Convert.ToDouble(exchange.convert.Text);
                try
                {
                    if (amount > 0)
                        result = Math.Round(amount * coins.Where(p => p.Symbol == exchange.conversionList.SelectedItem).Select(p => p.PriceUsd).First() / coins.Where(p => p.Symbol == exchange.conversionInList.SelectedItem).Select(p => p.PriceUsd).First(), 4);
                }
                catch
                {
                    exchange.convertIn.Content = "Choose currencies";
                }
            }
            catch
            {
                exchange.convertIn.Content = "Wrong Data";
            }
            return result;
        }
    }
}
