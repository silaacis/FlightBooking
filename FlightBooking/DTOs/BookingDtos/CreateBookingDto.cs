using FlightBooking.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FlightBooking.DTOs.BookingDtos
{
    public class CreateBookingDto
    {
        public string FlightId { get; set; }
        public string PnrNumber { get; set; } // 🔥 EKLE
        public List<Passenger> Passengers { get; set; }
        // 🔥 İletişim burada olmalı
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; }
    }
}
