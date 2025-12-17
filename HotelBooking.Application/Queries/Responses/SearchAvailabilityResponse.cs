using HotelBooking.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Queries.Responses
{
    public class SearchAvailabilityResponse
    {
        public IReadOnlyList<RoomDto> Rooms { get; init; }
    }
}
