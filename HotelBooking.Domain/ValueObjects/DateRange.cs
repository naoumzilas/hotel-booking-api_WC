using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.ValueObjects
{
    public sealed class DateRange
    {
        public DateOnly CheckIn { get; }
        public DateOnly CheckOut { get; }
        public DateRange(DateOnly checkIn, DateOnly checkOut)
        {
            if (checkOut <= checkIn)
            {
                throw new ArgumentException("Check-out date must be after check-in date");
            }
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public IEnumerable<DateOnly> GetNights()
        {
            for (var date = CheckIn; date < CheckOut; date = date.AddDays(1))
            {
                yield return date;
            }
        }
        public bool Overlaps(DateRange otherDate)
        {
            return CheckIn < otherDate.CheckOut && otherDate.CheckIn < CheckOut;
        }
    }
}
