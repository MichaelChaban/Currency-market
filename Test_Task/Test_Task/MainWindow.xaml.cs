using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Test_Task.ViewModels;

namespace Test_Task
{
    /// <summary>
    /// ViewModel for view MainWindow
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly MainViewModel mainViewModel;
        public MainWindow()
        {
            InitializeComponent();
            mainViewModel = new MainViewModel(this);
            mainViewModel.CreateList();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            mainViewModel.DisplayCoins();
        }

        private void searchInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            mainViewModel.FindCoin();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.ShowDetails();
        }

        private void exchange_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.ShowExchange();
        }

        public List<Coin> GetList()
        {
            return mainViewModel.Coins;
        }
    }
}