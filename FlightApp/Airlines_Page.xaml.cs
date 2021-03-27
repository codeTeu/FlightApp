using System.Windows;
using System.Windows.Controls;

namespace FlightApp
{
    /// <summary>
    /// Interaction logic for Airlines_Page.xaml
    /// </summary>
    public partial class Airlines_Page : Window
    {
        public Airlines_Page()
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

        private void lstBoxA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void mnuAddUser_Click(object sender, RoutedEventArgs e)
        {
            App.OpenWindow(new AddUser_Page(), this);
        }

        private void mnuHelp_Click(object sender, RoutedEventArgs e)
        {
            App.OpenWindow(new AboutWindow(), this);
        }

        private void mnuQuit_Click(object sender, RoutedEventArgs e)
        {
            App.QuitHandler();
        }

        private void rbBoe3_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbBoe4_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbBoe6_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbBoe5_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbBoe7_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbMealBurg_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbMealChic_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbMealVege_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbMealBeef_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbMealNdle_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
