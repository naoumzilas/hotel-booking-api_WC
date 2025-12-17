using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Queries.Requests
{
    public class SearchAvailabilityRequest
    {
        public Guid HotelId { get; init; }
        public DateOnly CheckIn { get; init; }
        public DateOnly CheckOut { get; init; }
        public int Guests { get; init; }
    }
}
