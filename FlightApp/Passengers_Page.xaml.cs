using System.Linq;
using System.Windows;

namespace FlightApp
{
    /// <summary>
    /// Interaction logic for Passengers_Page.xaml
    /// </summary>
    public partial class Passengers_Page : Window
    {

        private bool valid;

        public Passengers_Page()
        {
            InitializeComponent();
            RefreshListBox();
            App.HideMenuNotSuper(mnuAddUser);
        }


        /**
         * retrieves data from the list and display them on the listbox
         * used whenever any action is performed
         * index is the default selected item in the list
         */
        public void RefreshListBox(int selectedIndex = 0)
        {

            var fList = from fRec in App.GetFList()
                        join aRec in App.GetAList() on fRec.AirlineId
                        equals aRec.Id
                        select $"{fRec.Id}:  {aRec.Name} >> {fRec.DepartureCity} ------------> {fRec.DestinationCity}";


            var cList = from cRec in App.GetCList()
                        orderby (cRec.Name)
                        select cRec.Name;

            lstBoxF.DataContext = fList;
            lstBoxC.DataContext = cList;
            lstBoxF.SelectedIndex = selectedIndex;
            AssignListBoxP_ItemSource();
        }

        /**
         * assigns the listbox for passenger
         * 
         * retrieves the name of the customers 
         * using pRec and cRec customer ID as connection
         * 
         */
        public void AssignListBoxP_ItemSource()
        {
            var pList = from pRec in App.GetPList()
                        join cRec in App.GetCList() on pRec.CustomerId
                        equals cRec.Id
                        where pRec.FlightId == App.SelectedFRec(lstBoxF).Id
                        select cRec.Name;

            lstBoxP.DataContext = pList;
        }



        /**
         * whenever selection changes,
         * refreshes the listbox of passengers for selected flight
         */
        private void lstBoxF_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lstBoxF.SelectedItem != null)
            {
                AssignListBoxP_ItemSource();
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
            valid = App.IsSuperUser() &&
                    App.ListBoxHasItem(lstBoxP, 'd') &&
                    App.HasSelected(lstBoxP, lstBoxC, 'd') &&
                    App.SureAction('d');

            if (valid)
            {
                App.GetPList().Remove(App.SelectedPRec(lstBoxP));
                AssignListBoxP_ItemSource();
            }
        }


        private void mnuAddUser_Click(object sender, RoutedEventArgs e)
        {
            App.OpenWindow(new AddUser_Page(), this);
        }

        private void mnuQuit_Click(object sender, RoutedEventArgs e)
        {
            App.QuitHandler();
        }

        private void mnuHelp_Click(object sender, RoutedEventArgs e)
        {
            App.OpenWindow(new AboutWindow(), this);
        }


    }
}
