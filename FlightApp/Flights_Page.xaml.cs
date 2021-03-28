using FlightApp.Classes;
using System.Linq;
using System.Windows;

namespace FlightApp
{
    /// <summary>
    /// Interaction logic for Flights_Page.xaml
    /// </summary>
    public partial class Flights_Page : Window
    {
        private int airlineID = 0;
        private bool valid = false;

        public Flights_Page()
        {
            InitializeComponent();
            RefreshListBox();
            App.HideMenuNotSuper(mnuAddUser);
        }
        private void WindowClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.WindowCloseOpacity(this);
        }
        private void mnuAddUser_Click(object sender, RoutedEventArgs e)
        {
            App.OpenWindow(new AddUser_Page(), this);
        }

        private void mnuHelp_Click(object sender, RoutedEventArgs e)
        {
            App.OpenWindow(new AboutWindow(), this);
        }


        /**
         * retrieves data from the list and display them on the listbox
         * used whenever any action is performed
         * index is the default selected item in the list
         */
        public void RefreshListBox(int selectedIndex = 0)
        {
            var aList = from aRec in App.GetAList()
                        select aRec.Name;


            var fList = from fRec in App.GetFList()
                        join aRec in App.GetAList() on fRec.AirlineId
                        equals aRec.Id
                        select $"{fRec.Id}: {aRec.Name} >> {fRec.DepartureCity} ------------> {fRec.DestinationCity}";

            lstBoxA.DataContext = aList;
            lstBoxF.DataContext = fList;
            lstBoxF.SelectedIndex = selectedIndex;

            if (lstBoxF.Items.IsEmpty)
            {
                txtDepCity.Text = "";
                txtDestCity.Text = "";
                txtDepDate.Text = "";
                txtFlightTime.Text = "";
            }
        }


        /**
         * whenever selection changes,
         * retrieves the record of the selected item in the listbox then
         * assigns them to the textboxes
         */
        private void lstBoxF_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lstBoxF.SelectedItem != null)
            {
                var flightRec = from rec in App.GetFList()
                                where rec.Id == App.SelectedFRec(lstBoxF).Id
                                select rec;

                foreach (var fInfo in flightRec)
                {
                    txtDepCity.Text = fInfo.DepartureCity;
                    txtDestCity.Text = fInfo.DestinationCity;
                    txtDepDate.Text = fInfo.DepartureDate;
                    txtFlightTime.Text = fInfo.FlightTime.ToString();

                    var aName = from aRec in App.GetAList()
                                where aRec.Id == fInfo.AirlineId
                                select aRec.Name;

                    lstBoxA.SelectedItem = aName.First();
                }
            }

        }

        /**
         * whenever selection changes,
         * retrieves the record of the selected item in the listbox then
         * assigns them to the textboxes
         */
        private void lstBoxA_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            airlineID = App.SelectedARec(lstBoxA).Id;
        }



        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            valid = App.IsSuperUser() &&
                    App.HasCompleteInput(4, txtDepCity.Text, txtDestCity.Text, txtDepDate.Text, txtFlightTime.Text) &&
                    App.IsDouble(txtFlightTime.Text);

            if (valid)
            {
                App.GetFList().Add(new Flights(airlineID, txtDepCity.Text, txtDestCity.Text, txtDepDate.Text, double.Parse(txtFlightTime.Text)));
                RefreshListBox(lstBoxF.Items.Count);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            valid = App.IsSuperUser() &&
                    App.ListBoxHasItem(lstBoxF, 'u') &&
                    App.HasCompleteInput(4, txtDepCity.Text, txtDestCity.Text, txtDepDate.Text, txtFlightTime.Text) &&
                    App.IsDouble(txtFlightTime.Text) &&
                    App.SureAction('u');

            if (valid)
            {
                Flights fRec = App.SelectedFRec(lstBoxF);
                fRec.AirlineId = airlineID;
                fRec.DepartureCity = txtDepCity.Text;
                fRec.DestinationCity = txtDestCity.Text;
                fRec.DepartureDate = txtDepDate.Text;
                fRec.FlightTime = double.Parse(txtFlightTime.Text);

                RefreshListBox(lstBoxF.SelectedIndex);
            }
        }
        /**
         * deletes a record
         * check if super, list has item, ask if sure- shows error
         * also deletes passenger record if there is a matching flight id
         */
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            valid = App.IsSuperUser() &&
                    App.ListBoxHasItem(lstBoxF, 'd') &&
                    App.SureAction('d');

            if (valid)
            {

                var pRecList = from rec in App.GetPList()
                               where rec.FlightId == App.SelectedFRec(lstBoxF).Id
                               select rec;

                foreach (var rec in pRecList.ToList())
                {
                    App.GetPList().Remove(rec);
                }

                App.GetFList().Remove(App.SelectedFRec(lstBoxF));
                RefreshListBox();
            }
        }

        private void mnuQuit_Click(object sender, RoutedEventArgs e)
        {
            App.QuitHandler();
        }

        private void txtDepDate_Loaded(object sender, RoutedEventArgs e)
        {
            txtDepDate.BlackoutDates.AddDatesInPast();
        }
    }
}
