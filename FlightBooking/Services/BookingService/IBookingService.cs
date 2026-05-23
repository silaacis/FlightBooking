using FlightBooking.DTOs.BookingDtos;

namespace FlightBooking.Services.BookingService
{
    public interface IBookingService
    {
        Task CreateBookingAsync(CreateBookingDto createBookingDto);
        Task<(string Name, string Surname)> GetPassengersByIdAsync(string PassengerId);
        Task<string> GetPnrByPassengerIdAsync(string passengerId);
        Task<string> GetGateByPassengerIdAsync(string passengerId);
    }
}
