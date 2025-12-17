using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Queries.Responses
{
    public class BookingDetailsResponse
    {
        public string Reference { get; init; } = null!;
        public Guid HotelId { get; init; }
        public Guid RoomId { get; init; }
        public int GuestCount { get; init; }
        public DateOnly CheckIn { get; init; }
        public DateOnly CheckOut { get; init; }
    }
}
