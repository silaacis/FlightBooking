using FlightBooking.DTOs.BookingDtos;
using FlightBooking.Entities;
using FlightBooking.Services.BookingService;
using FlightBooking.Settings;
using MongoDB.Driver;

public class BookingService : IBookingService
{
    private readonly IMongoCollection<Booking> _bookingCollection;
    private readonly IMongoCollection<Flight> _flightCollection;

    public BookingService(IDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);

        _bookingCollection = database.GetCollection<Booking>(settings.BookingCollectionName);
        _flightCollection = database.GetCollection<Flight>(settings.FlightCollectionName);
    }

    public async Task CreateBookingAsync(CreateBookingDto createBookingDto)
    {
        // 🔥 1. Flight çek
        var flight = await _flightCollection
            .Find(x => x.FlightId == createBookingDto.FlightId)
            .FirstOrDefaultAsync();

        //if (flight == null)
        //    throw new Exception("Uçuş bulunamadı");

        // 🔥 2. Yolcu sayısı
        var passengerCount = createBookingDto.Passengers.Count;

        // 🔥 3. Koltuk kontrol
        //if (flight.AvailableSeats < passengerCount)
        //    throw new Exception("Yeterli koltuk yok");

        // 🔥 4. Passenger mapping
        var passengers = createBookingDto.Passengers.Select(x => new Passenger
        {
            Name = x.Name,
            Surname = x.Surname,
            BirthDate = x.BirthDate,
            Gender = x.Gender,
            PassengerType = x.PassengerType
        }).ToList();

        // 🔥 5. Fiyat hesaplama
        var totalPrice = passengerCount * flight.BasePrice;

        // 🔥 6. Booking oluştur
        var booking = new Booking
        {
            FlightId = createBookingDto.FlightId,
            Passengers = passengers,

            ContactName = createBookingDto.ContactName,
            ContactEmail = createBookingDto.ContactEmail,
            ContactPhone = createBookingDto.ContactPhone,

            TotalPrice = totalPrice,
            BookingDate = DateTime.Now,
            Status = "Confirmed"
        };

        await _bookingCollection.InsertOneAsync(booking);

        // 🔥 7. Koltuk düş
        //var update = Builders<Flight>.Update
        //    .Inc(x => x.AvailableSeats, -passengerCount);

        //await _flightCollection.UpdateOneAsync(
        //    x => x.FlightId == createBookingDto.FlightId,
        //    update
        //);
    }
}                    