using FlightApp.Classes;
using System.Collections.Generic;
using System.Windows;

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
         * closes the whole app
         */
        public static void QuitHandler()
        {
            if (SelectedButtonAfterMessage("askQuit") == MessageBoxResult.Yes)
            {
                Current.Shutdown();
            }
        }

        public static MessageBoxResult SelectedButtonAfterMessage(string err)
        {

            string title = "System Message";
            string message = "";

            if (err.Equals("askQuit"))
            {
                message = "You wish to close the whole application?";

            }

            MessageBoxResult result = MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result;
        }

    }



}
