using HotelBooking.Application.Interfaces;
using HotelBooking.Application.Queries.Requests;
using HotelBooking.Application.Queries.Responses;

namespace HotelBooking.Application.Services.Hotels;

public sealed class HotelService : IHotelService
{
    private readonly IHotelRepository _hotelRepository;

    public HotelService(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task<FindHotelByNameResponse> FindByNameAsync(FindHotelByNameRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new ArgumentException("Hotel name is required");
        }
        var hotel = await _hotelRepository.GetByNameAsync(request.Name, cancellationToken);

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
