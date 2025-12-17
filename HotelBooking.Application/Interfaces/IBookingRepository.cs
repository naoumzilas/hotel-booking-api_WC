using HotelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Interfaces
{
    public interface IBookingRepository
    {
        Task<IReadOnlyList<Booking>> GetBookingsForHotelAsync( Guid hotelId, CancellationToken cancellationToken);
        Task AddAsync(Booking booking, CancellationToken cancellationToken);
        Task<Booking> GetByReferenceAsync(string reference, CancellationToken cancellationToken);
    }
}
