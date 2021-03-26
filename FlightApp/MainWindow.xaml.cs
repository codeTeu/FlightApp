using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void btnVC_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnVF_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnVA_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnVP_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnuHelp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnuQuit_Click(object sender, RoutedEventArgs e)
        {
            App.QuitHandler();
        }

        private void mnuAddUser_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
