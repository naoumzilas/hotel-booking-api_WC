using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Queries.Requests
{
    public class FindHotelByNameRequest
    {
        public string Name { get; init; } = null!;
    }

}
