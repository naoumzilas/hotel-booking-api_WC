using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Queries.Requests
{
    public class GetBookingByReferenceRequest
    {
        public string Reference { get; init; } = null!;
    }
}
