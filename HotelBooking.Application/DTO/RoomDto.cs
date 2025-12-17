using HotelBooking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.DTO
{    public class RoomDto
    {
        public Guid RoomId { get; set; }
        public string RoomNumber { get; set; } = null!;
        public RoomType Type { get; set; }
        public int Capacity { get; set; }
    }
}