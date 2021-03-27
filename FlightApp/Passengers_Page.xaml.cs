using System.Windows;
using System.Windows.Controls;

namespace FlightApp
{
    /// <summary>
    /// Interaction logic for Passengers_Page.xaml
    /// </summary>
    public partial class Passengers_Page : Window
    {
        public Passengers_Page()
        {
            InitializeComponent();
        }

        private void WindowClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.WindowCloseOpacity(this);
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

        private void lstBoxF_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void mnuAddUser_Click(object sender, RoutedEventArgs e)
        {
            App.OpenWindow(new AddUser_Page(), this);
        }

        private void mnuQuit_Click(object sender, RoutedEventArgs e)
        {
            App.QuitHandler();
        }

        private void mnuHelp_Click(object sender, RoutedEventArgs e)
        {
            App.OpenWindow(new AboutWindow(), this);
        }


    }
}
