using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelBookingDbContext _dbContext;

        public RoomRepository(HotelBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Room>> GetRoomsForHotelAsync(Guid hotelId,CancellationToken cancellationToken)
        {
            return await _dbContext.Rooms.Where(r => r.HotelId == hotelId).ToListAsync(cancellationToken);
        }
    }
}
