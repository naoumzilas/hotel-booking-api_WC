using HotelBooking.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Entities
{
    public class Booking
    {
        public Guid Id { get; init; }
        public string Reference { get; private set; } = null!;

        public Guid HotelId { get; init; }
        public Guid RoomId { get; init; }

        public int GuestCount { get; private set; }
        public DateRange Stay { get; private set; }

        // Required by EF Core we need to materialise the enity from the DB
        protected Booking() { }

        /// <summary>
        /// Creates a new booking while enforcing core domain invariants.
        /// </summary>
        public Booking(string reference, Guid hotelId, Guid roomId, int guestCount, DateRange stay)
        {
            if (guestCount <= 0)
            {
                throw new ArgumentException("Guest count must be greater than zero");
            }

            Id = Guid.NewGuid();
            Reference = reference;
            HotelId = hotelId;
            RoomId = roomId;
            GuestCount = guestCount;
            Stay = stay;
        }
    }
}
