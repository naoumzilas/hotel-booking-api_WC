using HotelBooking.Application.Interfaces;
using HotelBooking.Application.Queries.Requests;
using HotelBooking.Application.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Handlers
{
    /// <summary>
    /// Handles the FindHotelByName query
    /// </summary>
    public class FindHotelByNameHandler
    {
        private readonly IHotelRepository _hotelRepository;

        public FindHotelByNameHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<FindHotelByNameResponse> HandleAsync(FindHotelByNameRequest query, CancellationToken cancellationToken)
        {
            var hotel = await _hotelRepository.GetByNameAsync(query.Name, cancellationToken);

            if (hotel is null)
            {
                return null;
            }

            return new FindHotelByNameResponse
            {
                HotelId = hotel.Id,
                Name = hotel.Name
            };
        }
    }
}
