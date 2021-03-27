using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FlightApp
{
    /// <summary>
    /// Interaction logic for Customers_Page.xaml
    /// </summary>
    public partial class Customers_Page : Window
    {
        public Customers_Page()
        {
            InitializeComponent();
            RefreshListBox();
            InitializeComponent();
            App.HideMenuNotSuper(mnuAddUser);
        }


        /**
         * retrieves data from the list and display them on the listbox
         * used whenever any action is performed
         * index is the default selected item in the list
         */
        public void RefreshListBox(int index = 0)
        {
            var list = from cRec in App.GetCList()
                       select cRec.Name;

            lstBoxC.DataContext = list;
            lstBoxC.SelectedIndex = index;

            if (lstBoxC.Items.IsEmpty)
            {
                txtName.Text = "";
                txtAddress.Text = "";
                txtEmail.Text = "";
                txtPhone.Text = "";
            }

        }


        /**
         * whenever selection changes,
         * retrieves the record of the selected item in the listbox then
         * assigns them to the textboxes
         */
        private void lstBoxC_SelectionChanged(object sender,
            System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var custRec = from rec in App.GetCList()
                          where rec.Name.Equals(lstBoxC.SelectedItem)
                          select rec;

            foreach (var custInfo in custRec)
            {
                txtName.Text = custInfo.Name;
                txtAddress.Text = custInfo.Address;
                txtEmail.Text = custInfo.Email;
                txtPhone.Text = custInfo.Phone;
            }
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
    }
}
