namespace FlightApp.Classes
{
    public class Flights
    {
        private static int count = 1;
        public int Id { get; set; }
        public int AirlineId { get; set; }  //foreign
        public string DepartureCity { get; set; }
        public string DestinationCity { get; set; }
        public string DepartureDate { get; set; }
        public double FlightTime { get; set; }

        public Flights(int aId, string depCity, string desCity, string depDate, double flightTime)
        {
            Id = count++;
            AirlineId = aId;
            DepartureCity = depCity;
            DestinationCity = desCity;
            DepartureDate = depDate;
            FlightTime = flightTime;
        }
    }
}
