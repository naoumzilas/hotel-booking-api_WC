using HotelBooking.Application.DTO;
using HotelBooking.Application.Queries.Requests;
using HotelBooking.Application.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Interfaces
{
    public interface IBookingService
    {
        Task<BookingDetailsResponse> CreateAsync(CreateBookingRequest request,CancellationToken cancellationToken);

        Task<BookingDetailsResponse> GetByReferenceAsync(GetBookingByReferenceRequest request,CancellationToken cancellationToken);
    }
}
