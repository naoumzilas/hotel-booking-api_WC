using HotelBooking.Application.Interfaces;
using HotelBooking.Application.Queries.Requests;
using HotelBooking.Application.Queries.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers;

/// <summary>
/// API controller for booking service
/// </summary>
[ApiController]
[Route("api/bookings")]
public sealed class BookingsController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingsController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    /// <summary>
    /// Creates a booking
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<BookingDetailsResponse>> Create([FromBody] CreateBookingRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _bookingService.CreateAsync(request, cancellationToken);

            return Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { error = ex.Message });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet("{reference}")]
    public async Task<ActionResult<BookingDetailsResponse>> GetByReference(string reference,CancellationToken cancellationToken)
    {
        try
        {
            var result = await _bookingService.GetByReferenceAsync(new GetBookingByReferenceRequest { Reference = reference }, cancellationToken);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
