using System.Windows;

namespace FlightApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            App.QuitHandler();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string usernameIn = txtUsername.Text;
            string pwdIn = pwdBox.Password;


            if (App.LoginValid(usernameIn, pwdIn))
            {
                MainWindow homePage = new MainWindow();
                homePage.Owner = this;
                homePage.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                homePage.ShowDialog();
            }
        }
    }
}
