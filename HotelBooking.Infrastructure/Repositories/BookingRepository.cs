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
    public sealed class BookingRepository : IBookingRepository
    {
        private readonly HotelBookingDbContext _dbContext;

        public BookingRepository(HotelBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Booking>> GetBookingsForHotelAsync(Guid hotelId, CancellationToken cancellationToken)
        {
            return await _dbContext.Bookings.Where(b => b.HotelId == hotelId).ToListAsync(cancellationToken);
        }

        public async Task AddAsync(Booking booking,CancellationToken cancellationToken)
        {
            _dbContext.Bookings.Add(booking);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Booking?> GetByReferenceAsync(string reference,CancellationToken cancellationToken)
        {
            return await _dbContext.Bookings.FirstOrDefaultAsync(b => b.Reference == reference,cancellationToken);
        }
    }
}
