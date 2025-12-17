using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;
using HotelBooking.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Api.Controllers;

/// <summary>
/// Admin/testing endpoints for seeding and resetting data.
/// </summary>
[ApiController]
[Route("api/admin")]
public sealed class AdminController : ControllerBase
{
    private readonly HotelBookingDbContext _dbContext;

    public AdminController(HotelBookingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Removes all data from the database.
    /// </summary>
    [HttpPost("reset")]
    public async Task<IActionResult> Reset(CancellationToken cancellationToken)
    {
        _dbContext.Bookings.RemoveRange(_dbContext.Bookings);
        _dbContext.Rooms.RemoveRange(_dbContext.Rooms);
        _dbContext.Hotels.RemoveRange(_dbContext.Hotels);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Ok(new { message = "Database reset completed!!!!" });
    }

    /// <summary>
    /// Seeds the database with deterministic test data.
    /// </summary>
    [HttpPost("seed")]
    public async Task<IActionResult> Seed(CancellationToken cancellationToken)
    {
        if (await _dbContext.Hotels.AnyAsync(cancellationToken))
        {
            return BadRequest("Database already seeded.");
        }

        var hotel = new Hotel("Test Hotel");

        var rooms = new[]
        {
            new Room(hotel.Id, "101", RoomType.Single, 1),
            new Room(hotel.Id, "102", RoomType.Single, 1),
            new Room(hotel.Id, "201", RoomType.Double, 2),
            new Room(hotel.Id, "202", RoomType.Double, 2),
            new Room(hotel.Id, "301", RoomType.Deluxe, 4),
            new Room(hotel.Id, "302", RoomType.Deluxe, 4),
        };

        hotel.AddRoom(rooms[0]);
        hotel.AddRoom(rooms[1]);
        hotel.AddRoom(rooms[2]);
        hotel.AddRoom(rooms[3]);
        hotel.AddRoom(rooms[4]);
        hotel.AddRoom(rooms[5]);

        _dbContext.Hotels.Add(hotel);
        _dbContext.Rooms.AddRange(rooms);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Ok(new
        {
            message = "Database seeded successfully!!!!",
            hotelId = hotel.Id
        });
    }
}
