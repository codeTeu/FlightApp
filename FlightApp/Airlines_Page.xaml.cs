using FlightApp.Classes;
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

                RadioButton[] rbPlanelArr = { rbBoe7, rbBoe6, rbBoe5, rbBoe4, rbBoe3 };
                foreach (var plane in rbPlanelArr)
                {
                    plane.IsChecked = aInfo.Airplane == plane.Content.ToString() ? true : false;
                }

                RadioButton[] rbMealArr = { rbMealChic, rbMealVege, rbMealBeef, rbMealBurg, rbMealNdle };
                foreach (var meal in rbMealArr)
                {
                    meal.IsChecked = aInfo.MealAvailable == meal.Content.ToString() ? true : false;
                }
            }
        }
        /**
         * assign meal and plane variables withh the radio button that was selected
         */
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

        /**
         * inserts new record
         * check if super, no empty input, phone is int, no duplicate name - shows error
         */
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            valid = App.IsSuperUser() &&
                    App.HasCompleteInput(2, txtName.Text, txtSeats.Text) &&
                    App.IsInt(txtSeats.Text);


            bool inList = App.NameInAList(txtName.Text);

            if (valid && !inList)
            {
                App.GetAList().Add(new Airlines(txtName.Text, airplane, int.Parse(txtSeats.Text), meal));
                RefreshListBox(lstBoxA.Items.Count);
            }
            else if (valid && inList)
            {
                App.GetError("nameInList");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            valid = App.IsSuperUser() &&
                    App.ListBoxHasItem(lstBoxA, 'u') &&
                    App.HasCompleteInput(2, txtName.Text, txtSeats.Text) &&
                    App.IsInt(txtSeats.Text) &&
                    App.SureAction('u');

            if (valid)
            {
                bool inList = App.NameInAList(txtName.Text);
                Airlines aRec = App.SelectedARec(lstBoxA);

                if (aRec.Name.Equals(txtName.Text) ||
                    !aRec.Name.Equals(txtName.Text) && !inList)
                {
                    aRec.Name = txtName.Text;
                    aRec.SeatsAvailable = int.Parse(txtSeats.Text);
                    aRec.Airplane = airplane;
                    aRec.MealAvailable = meal;

                    RefreshListBox(lstBoxA.SelectedIndex);
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
