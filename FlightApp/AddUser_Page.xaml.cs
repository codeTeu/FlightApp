using System.Windows;


namespace FlightApp
{
    /// <summary>
    /// Interaction logic for AddUser_Page.xaml
    /// </summary>
    public partial class AddUser_Page : Window
    {
        public AddUser_Page()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Owner.Opacity = .7;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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


        private void mnuQuit_Click(object sender, RoutedEventArgs e)
        {
            App.QuitHandler();
        }

        private void mnuHelp_Click(object sender, RoutedEventArgs e)
        {
            App.OpenWindow(new AboutWindow(), this);
        }

        private void chkSuper_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void lstBoxT_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void chkSuper_Unchecked(object sender, RoutedEventArgs e)
        {

        }
    }
}
