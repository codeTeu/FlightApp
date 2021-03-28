using System.Windows;
using System.Windows.Controls;
using System.Linq;
using FlightApp.Classes;

namespace FlightApp
{
    /// <summary>
    /// Interaction logic for AddUser_Page.xaml
    /// </summary>
    public partial class AddUser_Page : Window
    {
        private int superInt;

        public AddUser_Page()
        {
            InitializeComponent();
            RefreshListBox();
        }


        /**
         * retrieves data from the list and display them on the listbox
         * used whenever any action is performed
         * index is the default selected item in the list
         */
        public void RefreshListBox(int selectedIndex = 0)
        {
            var list = from tRec in App.GetTList()
                       select tRec.Username;

            lstBoxT.DataContext = list;
            lstBoxT.SelectedIndex = selectedIndex;

            if (lstBoxT.Items.IsEmpty)
            {
                txtUser.Text = "";
                pwdBox.Password = "";
                chkSuper.IsChecked = false;
            }

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
            if (App.HasCompleteInput(2, txtUser.Text, pwdBox.Password))
            {
                if (!App.NameInTList(txtUser.Text))
                {
                    App.GetTList().Add(new Table(txtUser.Text, pwdBox.Password, superInt));
                    RefreshListBox(lstBoxT.Items.Count);
                }
                else
                {
                    App.GetError("nameInList");
                }
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            bool valid = App.ListBoxHasItem(lstBoxT, 'u') &&
                           App.HasCompleteInput(2, txtUser.Text, pwdBox.Password) &&
                           App.SureAction('u');

            if (valid)
            {
                bool inList = App.NameInTList(txtUser.Text);
                Table tRec = App.SelectedTRec(lstBoxT);

                if (tRec.Username.Equals(txtUser.Text) ||
                    !tRec.Username.Equals(txtUser.Text) && !inList)
                {
                    tRec.Username = txtUser.Text;
                    tRec.Password = pwdBox.Password;
                    tRec.SuperUser = superInt;

                    RefreshListBox(lstBoxT.SelectedIndex);
                }
                else if (inList)
                {
                    App.GetError("nameInList");
                }
            }
        }
        /**
         * deletes a record
         * check if super, list has item, ask if sure- shows error
         * also deletes all flight records that has a matching id
         */
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (App.ListBoxHasItem(lstBoxT, 'd') && App.SureAction('d'))
            {
                App.GetTList().Remove(App.SelectedTRec(lstBoxT));
                RefreshListBox();
            }
        }


        private void mnuQuit_Click(object sender, RoutedEventArgs e)
        {
            App.QuitHandler();
        }

        private void mnuHelp_Click(object sender, RoutedEventArgs e)
        {
            App.OpenWindow(new AboutWindow(), this);
        }

        private void lstBoxT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstBoxT.SelectedItem != null)
            {
                Table rec = App.SelectedTRec(lstBoxT);
                txtUser.Text = rec.Username;
                pwdBox.Password = rec.Password;
                chkSuper.IsChecked = rec.SuperUser == 1 ? true : false;
            }
        }



        private void chkSuper_Unchecked(object sender, RoutedEventArgs e)
        {
            superInt = 0;
        }

        private void chkSuper_Checked(object sender, RoutedEventArgs e)
        {
            superInt = 1;
        }

    }
}
