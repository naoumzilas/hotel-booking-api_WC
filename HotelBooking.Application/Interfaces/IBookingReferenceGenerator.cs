using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Interfaces
{
    /// <summary>
    /// Generates unique booking reference
    /// </summary>
    public interface IBookingReferenceGenerator
    {
        string Generate();
    }
}
