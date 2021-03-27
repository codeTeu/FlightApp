using System.Windows;
using System.Windows.Controls;

namespace FlightApp
{
    /// <summary>
    /// Interaction logic for Flights_Page.xaml
    /// </summary>
    public partial class Flights_Page : Window
    {
        public Flights_Page()
        {
            InitializeComponent();
        }
        private void WindowClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.WindowCloseOpacity(this);
        }
        private void mnuAddUser_Click(object sender, RoutedEventArgs e)
        {
            App.OpenWindow(new AddUser_Page(), this);
        }

        private void mnuHelp_Click(object sender, RoutedEventArgs e)
        {
            App.OpenWindow(new AboutWindow(), this);
        }

        private void lstBoxA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lstBoxF_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnuQuit_Click(object sender, RoutedEventArgs e)
        {
            App.QuitHandler();
        }

        private void txtDepDate_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
