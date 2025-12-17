using HotelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Interfaces
{
    public interface IRoomRepository
    {
        Task<IReadOnlyList<Room>> GetRoomsForHotelAsync( Guid hotelId, CancellationToken cancellationToken);
    }
}
