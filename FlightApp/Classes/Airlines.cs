namespace FlightApp.Classes
{
    class Airlines
    {
        private static int count = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Airplane { get; set; } //Boeing 777, Airbuss 320
        public int SeatsAvailable { get; set; }
        public string MealAvailable { get; set; } //chicken, sushi, salad

        public Airlines(string name, string airplane, int seatsAvail, string mealAvail)
        {
            Id = count++;
            Name = name;
            Airplane = airplane;
            SeatsAvailable = seatsAvail;
            MealAvailable = mealAvail;
        }

    }
}
