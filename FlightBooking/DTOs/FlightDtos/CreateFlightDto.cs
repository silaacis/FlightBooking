namespace FlightBooking.DTOs.FlightDtos
{
    public class CreateFlightDto
    {
        public string FlightNumber { get; set; } //TK1234, PC2023
        public string AirlineCode { get; set; } //TK, PC, LH

        public string DepartureAirportCode { get; set; } //IST, JFK, LHR
        public string DepartureAirportName { get; set; } // Istanbul Airport, John F. Kennedy International Airport
        public string ArrivalAirportCode { get; set; } //LHR, CDG, FRA
        public string ArrivalAirportName { get; set; } //London Heathrow Airport, Charles de Gaulle Airport

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int DurationMinutes { get; set; }

        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }

        public decimal BasePrice { get; set; }
        public string Currency { get; set; } //USD, EUR, TRY
        public string Status { get; set; } //Scheduled, Delayed, Cancelled, Boarding, Departed
    }
}
