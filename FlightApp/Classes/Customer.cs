namespace FlightApp.Classes
{
    class Customer
    {
        private static int count = 1;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Customer(string name, string address, string email, string phone)
        {
            Id = count++;
            Name = name;
            Address = address;
            Email = email;
            Phone = phone;
        }
    }
}
