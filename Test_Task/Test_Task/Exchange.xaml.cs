using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Test_Task.ViewModels;

namespace Test_Task
{
    /// <summary>
    /// Interaction logic for Exchange.xaml
    /// </summary>
    public partial class Exchange : Window
    {
        readonly ExchangeViewModel exchangeViewModel;

        public Exchange(List<Coin> coins)
        {
            InitializeComponent();
            exchangeViewModel = new ExchangeViewModel(this, coins);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            exchangeViewModel.DisplayData();
        }

        private void convert_TextChanged(object sender, TextChangedEventArgs e)
        {
            exchangeViewModel.ClickTypeConvert();
        }

        private void convertBtn_Click(object sender, RoutedEventArgs e)
        {
            exchangeViewModel.ClickTypeConvert();
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
