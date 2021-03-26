using System;
using System.Windows;

namespace FlightApp
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void CloseWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Opacity = 1;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            this.Owner.Opacity = .7;
        }
    }
}
