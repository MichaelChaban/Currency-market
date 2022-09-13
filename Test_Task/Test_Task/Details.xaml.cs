using System.Windows;
using Test_Task.ViewModels;

namespace Test_Task
{
    /// <summary>
    /// ViewModel for view Details
    /// </summary>
    public partial class Details : Window
    {
        readonly DetailsViewModel detailsViewModel;

        public Details()
        {
            InitializeComponent();
            detailsViewModel = new DetailsViewModel(this);
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            detailsViewModel.CreateDisplayList();
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}