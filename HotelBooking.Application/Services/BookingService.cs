using HotelBooking.Application.Interfaces;
using HotelBooking.Application.Queries.Requests;
using HotelBooking.Application.Queries.Responses;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.ValueObjects;

namespace HotelBooking.Application.Services.Bookings;

/// <summary>
/// Application service responsible for creating bookings
/// </summary>
public class BookingService : IBookingService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IBookingRepository _bookingRepository;
    private readonly IBookingReferenceGenerator _referenceGenerator;

    public BookingService(IRoomRepository roomRepository, IBookingRepository bookingRepository, IBookingReferenceGenerator referenceGenerator)
    {
        _roomRepository = roomRepository;
        _bookingRepository = bookingRepository;
        _referenceGenerator = referenceGenerator;
    }

    public async Task<BookingDetailsResponse> CreateAsync(CreateBookingRequest request, CancellationToken cancellationToken)
    {
        var stay = new DateRange(request.CheckIn, request.CheckOut);

        var rooms = await _roomRepository.GetRoomsForHotelAsync(request.HotelId, cancellationToken);

        var bookings = await _bookingRepository.GetBookingsForHotelAsync(request.HotelId, cancellationToken);

        var room = rooms
            .Where(r => r.CanAccommodate(request.Guests))
            .FirstOrDefault(r => !bookings.Any(b => b.RoomId == r.Id && b.Stay.Overlaps(stay)));

        if (room is null)
        {
            throw new InvalidOperationException("No available room found");
        }
        var booking = new Booking
            (
            reference: _referenceGenerator.Generate(),
            hotelId: request.HotelId,
            roomId: room.Id,
            guestCount: request.Guests,
            stay: stay
            );

        await _bookingRepository.AddAsync(booking, cancellationToken);

        return new BookingDetailsResponse
        {
            Reference = booking.Reference,
            HotelId = booking.HotelId,
            RoomId = booking.RoomId,
            GuestCount = booking.GuestCount,
            CheckIn = booking.Stay.CheckIn,
            CheckOut = booking.Stay.CheckOut
        };

    }

    public async Task<BookingDetailsResponse?> GetByReferenceAsync(GetBookingByReferenceRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Reference))
        {
            throw new ArgumentException("Booking reference is required.");
        }
        var booking = await _bookingRepository.GetByReferenceAsync(request.Reference, cancellationToken);

        if (booking is null)
        {
            return null;
        }

        return new BookingDetailsResponse
        {
            Reference = booking.Reference,
            HotelId = booking.HotelId,
            RoomId = booking.RoomId,
            GuestCount = booking.GuestCount,
            CheckIn = booking.Stay.CheckIn,
            CheckOut = booking.Stay.CheckOut
        };
    }
}
