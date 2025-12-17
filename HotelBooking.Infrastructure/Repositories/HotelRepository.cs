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
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelBookingDbContext _dbContext;
        public HotelRepository(HotelBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Hotel?> GetByNameAsync(string name,CancellationToken cancellationToken)
        {
            return await _dbContext.Hotels.Include(h => h.Rooms).FirstOrDefaultAsync(h => h.Name.ToLower() == name.ToLower(), cancellationToken);
        }

        public async Task<Hotel?> GetByIdAsync( Guid hotelId, CancellationToken cancellationToken)
        {
            return await _dbContext.Hotels.Include(h => h.Rooms).FirstOrDefaultAsync(h => h.Id == hotelId, cancellationToken);
        }
    }
}
