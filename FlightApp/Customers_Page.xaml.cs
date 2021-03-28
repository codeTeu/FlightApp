using FlightApp.Classes;
using System.Linq;
using System.Windows;

namespace FlightApp
{
    /// <summary>
    /// Interaction logic for Customers_Page.xaml
    /// </summary>
    public partial class Customers_Page : Window
    {

        private bool valid;

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

        /**
         * inserts new record
         * check if super, no empty input, phone iss int, no duplicate name - shows error
         */
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            valid = App.IsSuperUser() &&
                    App.HasCompleteInput(4, txtName.Text, txtAddress.Text, txtEmail.Text, txtPhone.Text) &&
                    App.IsInt(txtPhone.Text);

            bool inList = App.NameInCList(txtName.Text);

            if (valid && !inList)
            {
                App.GetCList().Add(new Customer(txtName.Text, txtAddress.Text, txtEmail.Text, txtPhone.Text));
                RefreshListBox(lstBoxC.Items.Count);
            }
            else if (valid && inList)
            {
                App.GetError("nameInList");
            }

        }

        /**
         * updates a record
         * check if super, list is not empty, no empy input, 
         * no duplicate name, phone is int, ask if sure - show error
         */
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            valid = App.IsSuperUser() &&
                    App.ListBoxHasItem(lstBoxC, 'u') &&
                    App.HasCompleteInput(4, txtName.Text, txtAddress.Text, txtEmail.Text, txtPhone.Text) &&
                    App.IsInt(txtPhone.Text) &&
                    App.SureAction('u');

            bool inList = App.NameInCList(txtName.Text);
            Customer cRec = App.SelectedCRec(lstBoxC);

            if (valid)
            {
                if (cRec.Name.Equals(txtName.Text) ||
                    !cRec.Name.Equals(txtName.Text) && !inList)
                {
                    cRec.Name = txtName.Text;
                    cRec.Address = txtAddress.Text;
                    cRec.Email = txtEmail.Text;
                    cRec.Phone = txtPhone.Text;

                    RefreshListBox(lstBoxC.SelectedIndex);
                }
                else if (inList)
                {
                    App.GetError("nameInList");
                }
            }


        }

        /**
         * deletes a record
         * check if super, list has item, ask if sure - shows error
         * also deletes passenger record in they are in the passenger list
         */
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            valid = App.IsSuperUser() &&
                    App.ListBoxHasItem(lstBoxC, 'd') &&
                    App.SureAction('d');

            if (valid)
            {

                var pRec = from rec in App.GetPList()
                           where rec.CustomerId == App.SelectedCRec(lstBoxC).Id
                           select rec;

                foreach (var item in pRec.ToList())
                {
                    App.GetPList().Remove(item);
                }

                App.GetCList().Remove(App.SelectedCRec(lstBoxC));
                RefreshListBox();
            }
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
