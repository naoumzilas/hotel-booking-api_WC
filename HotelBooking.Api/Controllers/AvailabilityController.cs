using HotelBooking.Application.Interfaces;
using HotelBooking.Application.Queries.Requests;
using HotelBooking.Application.Queries.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers;

/// <summary>
/// API controller for room availability check
/// </summary>
[ApiController]
[Route("api/availability")]
public sealed class AvailabilityController : ControllerBase
{
    private readonly IRoomAvailabilityService _availabilityService;

    public AvailabilityController(IRoomAvailabilityService availabilityService)
    {
        _availabilityService = availabilityService;
    }

    /// <summary>
    /// Searches for available rooms in a hotel.
    /// </summary>
    [HttpPost("search")]
    public async Task<ActionResult<SearchAvailabilityResponse>> Search([FromBody] SearchAvailabilityRequest request,CancellationToken cancellationToken)
    {
        try
        {
            var result = await _availabilityService.SearchAsync(request, cancellationToken);

            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
