using FlightBooking.DTOs.BookingDtos;

namespace FlightBooking.Services.BookingService
{
    public interface IBookingService
    {
        Task CreateBookingAsync(CreateBookingDto createBookingDto);
    }
}
