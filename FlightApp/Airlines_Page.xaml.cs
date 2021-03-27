using System.Linq;
using System.Windows;

namespace FlightApp
{
    /// <summary>
    /// Interaction logic for Airlines_Page.xaml
    /// </summary>
    public partial class Airlines_Page : Window
    {
        private string airplane = "";
        private string meal = "";

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
        //AIRPLANE
        private void rbBoe7_Checked(object sender, RoutedEventArgs e)
        {
            airplane = rbBoe7.Content.ToString();
        }

        private void rbBoe6_Checked(object sender, RoutedEventArgs e)
        {
            airplane = rbBoe6.Content.ToString();
        }
        private void rbBoe5_Checked(object sender, RoutedEventArgs e)
        {
            airplane = rbBoe5.Content.ToString();
        }

        private void rbBoe4_Checked(object sender, RoutedEventArgs e)
        {
            airplane = rbBoe4.Content.ToString();
        }
        private void rbBoe3_Checked(object sender, RoutedEventArgs e)
        {
            airplane = rbBoe3.Content.ToString();
        }

        //MEAL
        private void rbMealChic_Checked(object sender, RoutedEventArgs e)
        {
            meal = rbMealChic.Content.ToString();
        }

        private void rbMealVege_Checked(object sender, RoutedEventArgs e)
        {
            meal = rbMealVege.Content.ToString();
        }

        private void rbMealBeef_Checked(object sender, RoutedEventArgs e)
        {
            meal = rbMealBeef.Content.ToString();
        }

        private void rbMealBurg_Checked(object sender, RoutedEventArgs e)
        {
            meal = rbMealBurg.Content.ToString();
        }

        private void rbMealNdle_Checked(object sender, RoutedEventArgs e)
        {
            meal = rbMealNdle.Content.ToString();
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
