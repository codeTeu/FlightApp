namespace FlightApp.Classes
{
    public class Passenger
    {
        private static int count = 1;

        public int Id { get; set; }
        public int CustomerId { get; set; } //foreign
        public int FlightId { get; set; }   //foreign
        public Passenger(int custId, int flightId)
        {
            Id = count++;
            CustomerId = custId;
            FlightId = flightId;
        }
    }
}
