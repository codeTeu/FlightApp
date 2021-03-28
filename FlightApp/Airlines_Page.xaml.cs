using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FlightApp
{
    /// <summary>
    /// Interaction logic for Airlines_Page.xaml
    /// </summary>
    public partial class Airlines_Page : Window
    {
        private string airplane = "";
        private string meal = "";
        private bool valid;

        public Airlines_Page()
        {
            InitializeComponent();
            RefreshListBox();
            App.HideMenuNotSuper(mnuAddUser);
        }

        private void WindowClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.WindowCloseOpacity(this);
        }


        /**
         * retrieves data from the list and display them on the listbox
         * used whenever any action is performed
         * index is the default selected item in the list
         */
        public void RefreshListBox(int selectedIndex = 0)
        {
            var list = from aRec in App.GetAList()
                       select aRec.Name;

            lstBoxA.DataContext = list;
            lstBoxA.SelectedIndex = selectedIndex;

            if (lstBoxA.Items.IsEmpty)
            {
                txtName.Text = "";
                txtSeats.Text = "";
                rbBoe7.IsChecked = true;
                rbMealChic.IsChecked = true;
            }
        }



        /**
         * change values based on selected
         */
        private void lstBoxA_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            var airlineRec = from rec in App.GetAList()
                             where rec.Name.Equals(lstBoxA.SelectedItem)
                             select rec;

            foreach (var aInfo in airlineRec)
            {
                txtName.Text = aInfo.Name;
                txtSeats.Text = aInfo.SeatsAvailable.ToString();

                rbBoe7.IsChecked = aInfo.Airplane == rbBoe7.Content.ToString() ? true : false;
                rbBoe6.IsChecked = aInfo.Airplane == rbBoe6.Content.ToString() ? true : false;
                rbBoe5.IsChecked = aInfo.Airplane == rbBoe5.Content.ToString() ? true : false;
                rbBoe4.IsChecked = aInfo.Airplane == rbBoe4.Content.ToString() ? true : false;
                rbBoe3.IsChecked = aInfo.Airplane == rbBoe3.Content.ToString() ? true : false;

                rbMealChic.IsChecked = aInfo.MealAvailable == rbMealChic.Content.ToString() ? true : false;
                rbMealVege.IsChecked = aInfo.MealAvailable == rbMealVege.Content.ToString() ? true : false;
                rbMealBeef.IsChecked = aInfo.MealAvailable == rbMealBeef.Content.ToString() ? true : false;
                rbMealBurg.IsChecked = aInfo.MealAvailable == rbMealBurg.Content.ToString() ? true : false;
                rbMealNdle.IsChecked = aInfo.MealAvailable == rbMealNdle.Content.ToString() ? true : false;
            }
        }

        private void radioBtn_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton button = ((RadioButton)sender);

            if (button.GroupName.Equals("meal"))
            {
                meal = ((RadioButton)sender).Content.ToString();
            }
            else if (button.GroupName.Equals("plane"))
            {
                airplane = ((RadioButton)sender).Content.ToString();
            }
        }


            private void btnInsert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        /**
         * deletes a record
         * check if super, list has item, ask if sure- shows error
         */
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            valid = App.IsSuperUser() &&
                    App.ListBoxHasItem(lstBoxA, 'd') &&
                    App.SureAction('d');

            if (valid)
            {
                App.GetAList().Remove(App.SelectedARec(lstBoxA));
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
