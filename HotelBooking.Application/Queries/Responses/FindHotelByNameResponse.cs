using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Queries.Responses
{
    public class FindHotelByNameResponse
    {
        public Guid HotelId { get; init; }
        public string Name { get; init; } = null!;
    }
}
