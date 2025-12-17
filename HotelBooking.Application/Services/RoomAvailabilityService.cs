using HotelBooking.Application.DTO;
using HotelBooking.Application.Interfaces;
using HotelBooking.Application.Queries.Requests;
using HotelBooking.Application.Queries.Responses;
using HotelBooking.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Services
{
    public class RoomAvailabilityService : IRoomAvailabilityService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IBookingRepository _bookingRepository;

        public RoomAvailabilityService(IRoomRepository roomRepository,IBookingRepository bookingRepository)
        {
            _roomRepository = roomRepository;
            _bookingRepository = bookingRepository;
        }

        public async Task<SearchAvailabilityResponse> SearchAsync(SearchAvailabilityRequest request,CancellationToken cancellationToken)
        {
            var stay = new DateRange(request.CheckIn, request.CheckOut);

            var rooms = await _roomRepository.GetRoomsForHotelAsync(request.HotelId, cancellationToken);

            var bookings = await _bookingRepository.GetBookingsForHotelAsync(request.HotelId, cancellationToken);

            var availableRooms = rooms.Where(r => r.CanAccommodate(request.Guests)).Where(r => !bookings.Any(b => b.RoomId == r.Id && b.Stay.Overlaps(stay)))
                .Select(r => new RoomDto
                {
                    RoomId = r.Id,
                    RoomNumber = r.RoomNumber,
                    Type = r.Type,
                    Capacity = r.Capacity
                })
                .ToList();

            return new SearchAvailabilityResponse
            {
                Rooms = availableRooms
            };
        }

    }
}
