using FlightApp.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FlightApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //LISTS
        private static List<Table> tList = new List<Table>()
        {
            new Table("user1","pwd1", 1),
            new Table("user2","pwd2", 1),
            new Table("user3","pwd3", 1),
            new Table("user4","pwd4", 0),
            new Table("user5","pwd5", 0)
        };

        private static List<Customer> cList = new List<Customer>()
        {
            new Customer("Ron", "Aven Street.", "ron@gmail.com", "1136631"),
            new Customer("Bon", "Lifa Street.", "bon@gmail.com", "2123321"),
            new Customer("Leo", "Pace Street.", "leo@gmail.com", "2235124"),
            new Customer("Lola", "Bill Street.", "lola@gmail.com", "5673453"),
            new Customer("Alex", "Fund Street.", "alex@gmail.com", "2048274"),
            new Customer("Ema", "Fire Street.", "ema@gmail.com", "8572634"),
            new Customer("Tylee", "Tear Street.", "tylee@gmail.com", "5673453"),
            new Customer("Nano", "Cove Street.", "nano@gmail.com", "2945723")
        };

        private static List<Airlines> aList = new List<Airlines>()
        {
            new Airlines("All Nippon Airways", "Boeing 700", 700, "Chicken"),
            new Airlines("Japan Airlines", "Boeing 600", 600, "Vegetable"),
            new Airlines("Jetstar Japan", "Boeing 500", 500, "Beef"),
            new Airlines("Sakura Airways", "Boeing 400", 400, "Burger"),
            new Airlines("Skymark Airline", "Boeing 300", 300, "Noodle"),
        };

        private static List<Flights> fList = new List<Flights>()
        {
            new Flights(1,"Tokyo", "Osaka", System.DateTime.Today.AddDays(1).ToString(), 1.5),
            new Flights(2,"Okinawa", "Nagoya", System.DateTime.Today.AddMonths(1).ToString(), 2),
            new Flights(3,"Fukuoka", "Sapporo", System.DateTime.Today.AddDays(3).ToString(), 3.5),
            new Flights(4,"Tokyo", "Osaka", System.DateTime.Today.AddDays(7).ToString(), 4),
            new Flights(5,"Kobe", "Hakone", System.DateTime.Today.AddDays(21).ToString(), 5),
        };

        private static List<Passenger> pList = new List<Passenger>()
        {
            new Passenger(1,1),
            new Passenger(2,2),
            new Passenger(3,3),
            new Passenger(4,4),
            new Passenger(5,5)
        };

        public static List<Table> GetTList() => tList;
        public static List<Customer> GetCList() => cList;
        public static List<Airlines> GetAList() => aList;
        public static List<Flights> GetFList() => fList;
        public static List<Passenger> GetPList() => pList;

        /**
         * open help/about window
         */
        public static void OpenWindow(Window newWindow, Window sender)
        {
            newWindow.Owner = sender;
            newWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newWindow.ShowDialog();
        }

        /**
         * checks for a match in the tList
         * if match, sets super stat
         * error if not match
         */
        private static bool SuperStat { get; set; } = false;
        public static bool LoginValid(string username, string password)
        {
            foreach (var item in GetTList())
            {
                if (item.Username.Equals(username) && item.Password.Equals(password))
                {
                    SuperStat = item.SuperUser == 1 ? true : false;
                    return true;
                }
            }

            GetError("loginErr");
            return false;
        }

        public static void GetError(string err)
        {

            string title = "System Message";
            string message = "";

            if (err.Equals("loginErr"))
            {
                message = "Username or Password is wrong.";
            }
            else if (err.Equals("noEmpty"))
            {
                message = "Input can't be empty";
            }
            else if (err.Equals("notSuper"))
            {
                message = "You are not a super user";
            }
            else if (err.Equals("phoneNotNum"))
            {
                message = "Phone must be a number.";
            }
            else if (err.Equals("nameInList"))
            {
                message = "Name already in the list.";
            }
            else if (err.Equals("noUpdate"))
            {
                message = "Nothing to update.";

            }
            else if (err.Equals("noDelete"))
            {
                message = "Nothing to delete.";
            }
            else if (err.Equals(""))
            {

            }

            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /**
         * closes the whole app
         */
        public static void QuitHandler()
        {
            if (SelectedButtonAfterMessage("askQuit") == MessageBoxResult.Yes)
            {
                Current.Shutdown();
            }
        }

        public static void WindowCloseOpacity(Window wd)
        {
            wd.Owner.Opacity = 1;
        }
        public static MessageBoxResult SelectedButtonAfterMessage(string err)
        {

            string title = "System Message";
            string message = "";

            if (err.Equals("askQuit"))
            {
                message = "You wish to close the whole application?";

            }
            else if (err.Equals("askUpdate"))
            {
                message = "Update this record?";
            }
            else if (err.Equals("askDelete"))
            {
                message = "Delete this record?";
            }


            MessageBoxResult result = MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result;
        }


        /**
         * hides the add user menu if not a super user
         */
        public static void HideMenuNotSuper(MenuItem menu)
        {
            if (!SuperStat)
            {
                menu.Visibility = Visibility.Collapsed;
            }
        }



        public static Airlines SelectedARec(ListBox listBox)
        {
            if (!listBox.Items.IsEmpty)
            {
                var temp = from rec in GetAList()
                           where rec.Name.Equals(listBox.SelectedItem)
                           select rec;

                return temp == null ? null : temp.First();
            }

            return null;
        }

        public static Customer SelectedCRec(ListBox listBox)
        {
            if (!listBox.Items.IsEmpty)
            {
                var temp = from rec in GetCList()
                           where rec.Name.Equals(listBox.SelectedItem)
                           select rec;

                return temp == null ? null : temp.First();
            }

            return null;
        }


        public static Flights SelectedFRec(ListBox listBox)
        {
            if (!listBox.Items.IsEmpty)
            {

                string selectedItem = listBox.SelectedItem.ToString();
                int indexOfColon = selectedItem.IndexOf(':');

                int fIndex = int.Parse(selectedItem.Substring(0, indexOfColon));


                var temp = from rec in GetFList()
                           where rec.Id == fIndex
                           select rec;

                return temp == null ? null : temp.First();
            }

            return null;
        }


        public static Table SelectedTRec(ListBox listBox)
        {
            if (!listBox.Items.IsEmpty)
            {
                var temp = from rec in GetTList()
                           where rec.Username.Equals(listBox.SelectedItem)
                           select rec;

                return temp == null ? null : temp.First();
            }

            return null;
        }



        /**
         * shows error message if not super user
         * doesnt show error when in the main window
         */
        public static bool IsSuperUser()
        {
            if (Current.MainWindow.IsFocused)
            {

            }

            else if (SuperStat)
            {

                return true;
            }
            else
            {
                GetError("notSuper");
            }

            return false;

        }



        public static bool ListBoxHasItem(ListBox listBox, char updateOrDelete)
        {
            if (listBox.Items.IsEmpty)
            {
                GetError(updateOrDelete == 'u' ? "noUpdate" : "noDelete");
                return false;
            }
            return true;
        }



        /**
         * aks user if they are sure of their action  
         */
        public static bool SureAction(char btnAction)
        {
            string errAction = btnAction == 'd' ? "askDelete" : "askUpdate";

            return SelectedButtonAfterMessage(errAction) == MessageBoxResult.Yes ? true : false;
        }


        public static bool NameInCList(object nameIn)
        {

            foreach (var rec in GetCList())
            {
                if (rec.Name.Equals(nameIn.ToString()))
                {
                    return true;
                }
            }
            return false;

        }

        public static bool IsInt(string value)
        {
            try
            {
                int.Parse(value);
                return true;
            }
            catch
            {
                GetError("phoneNotNum");
                return false;
            }
        }


        /**
         * check if any input has empty values
         */
        public static bool HasCompleteInput(int numToCheck, string val1 = "", string val2 = "", string val3 = "", string val4 = "")
        {
            switch (numToCheck)
            {
                case 2:
                    if (val1.Equals("") || val2.Equals(""))
                    {
                        GetError("noEmpty");
                        return false;
                    }
                    break;
                case 4:
                    if (val1.Equals("") || val2.Equals("") || val3.Equals("") || val4.Equals(""))
                    {
                        GetError("noEmpty");
                        return false;
                    }
                    break;
            }

            return true;
        }

    }



}
