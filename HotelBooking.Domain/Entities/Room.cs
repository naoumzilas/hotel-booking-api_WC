using HotelBooking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Entities
{
    public class Room
    {
        public Guid Id { get; init; }
        public Guid HotelId { get; init; }

        public string RoomNumber { get; private set; } = null!;
        public RoomType Type { get; private set; }
        public int Capacity { get; private set; }

        // Required by EF Core we need to materialise the enity from the DB
        protected Room() { }

        public Room(Guid hotelId,string roomNumber,RoomType type, int capacity)
        {
            Id = Guid.NewGuid();
            HotelId = hotelId;
            RoomNumber = roomNumber;
            Type = type;
            Capacity = capacity;
        }

        public bool CanAccommodate(int guests)
            => guests <= Capacity;
    }
}
