using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Entities
{
    public class Hotel
    {
        public Guid Id { get; init; }
        public string Name { get; private set; } = null!;

        private readonly List<Room> _rooms = new();
        public IReadOnlyCollection<Room> Rooms => _rooms.AsReadOnly();

        // Required by EF Core we need to materialise the entity from the DB
        protected Hotel() { }

        public Hotel(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        /// <summary>
        /// Adds a room to the hotel.
        /// This is expected to be called during initial setup or seeding.
        /// </summary>
        public void AddRoom(Room room)
        {
            _rooms.Add(room);
        }
    }
}
