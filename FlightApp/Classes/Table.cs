namespace FlightApp.Classes
{
    class Table
    {
        private static int count = 1;
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int SuperUser { get; set; }

        public Table(string username, string password, int superuser)
        {
            Id = count++;
            Username = username;
            Password = password;
            SuperUser = superuser;
        }
    }
}
