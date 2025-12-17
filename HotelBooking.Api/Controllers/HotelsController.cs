using HotelBooking.Application.Interfaces;
using HotelBooking.Application.Queries.Requests;
using HotelBooking.Application.Queries.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers;

/// <summary>
/// API controller for hotel service
/// </summary>
[ApiController]
[Route("api/hotels")]
public sealed class HotelsController : ControllerBase
{
    private readonly IHotelService _hotelService;

    public HotelsController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }

    /// <summary>
    /// Finds a hotel by name
    /// </summary>
    [HttpPost("search")]
    public async Task<ActionResult<FindHotelByNameResponse>> Search([FromBody] FindHotelByNameRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var hotel = await _hotelService.FindByNameAsync(request, cancellationToken);

            if (hotel is null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
