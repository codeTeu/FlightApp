using System.Windows;

namespace FlightApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {


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
