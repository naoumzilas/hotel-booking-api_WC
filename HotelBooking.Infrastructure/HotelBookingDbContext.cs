using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure
{
    /// <summary>
    /// EF Core DbContext for the hotel booking system.
    /// This is the only place where EF Core is allowed to touch domain entities.
    /// </summary>
    public sealed class HotelBookingDbContext : DbContext
    {
        public DbSet<Hotel> Hotels => Set<Hotel>();
        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<Booking> Bookings => Set<Booking>();

        public HotelBookingDbContext(DbContextOptions<HotelBookingDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HotelBookingDbContext).Assembly);
        }
    }
}
