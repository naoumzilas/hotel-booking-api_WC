using HotelBooking.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Services
{
    /// <summary>
    /// Default booking reference generator. Later than can be extended into a 3rd Party booking provider that will generate the value
    /// </summary>
    public class BookingReferenceGenerator : IBookingReferenceGenerator
    {
        public string Generate()
        {
            return $"WarC-{Guid.NewGuid()}".ToString();
        }
    }
}
