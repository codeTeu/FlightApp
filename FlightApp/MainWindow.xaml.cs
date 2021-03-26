using System.Windows;

namespace FlightApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            App.HideMenuNotSuper(mnuAddUser);
        }


        /**
         * closes any active window
         * then opens a new specified window
         */
        public void OpenWindow(Window pageToOpen)
        {
            Window activeWindow = pageToOpen;
            activeWindow.Owner = this;
            activeWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.Opacity = .7;
            activeWindow.ShowDialog();
        }
        private void btnVC_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow(new Customers_Page());
        }

        private void btnVF_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow(new Flights_Page());
        }

        private void btnVA_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow(new Airlines_Page());
        }

        private void btnVP_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow(new Passengers_Page());
        }

        private void mnuHelp_Click(object sender, RoutedEventArgs e)
        {
            App.OpenWindow(new AboutWindow(), this);
        }

        private void mnuQuit_Click(object sender, RoutedEventArgs e)
        {
            App.QuitHandler();
        }

        private void mnuAddUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Owner.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                this.Owner.Show();
                this.Owner.Focus();
            }
        }
    }
}
