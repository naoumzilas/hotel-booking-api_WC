using FluentAssertions;
using HotelBooking.Application.Interfaces;
using HotelBooking.Application.Queries.Requests;
using HotelBooking.Application.Services;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;
using Moq;

public sealed class RoomAvailabilityServiceTests
{
    [Fact]
    public async Task Returns_available_room_when_no_bookings_exist()
    {
        // Arrange
        var roomRepo = new Mock<IRoomRepository>();
        var bookingRepo = new Mock<IBookingRepository>();

        var hotelId = Guid.NewGuid();

        roomRepo.Setup(r => r.GetRoomsForHotelAsync(hotelId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Room>
            {
                new Room(hotelId, "101", RoomType.Single, 1)
            });

        bookingRepo.Setup(b => b.GetBookingsForHotelAsync(hotelId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Booking>());

        var service = new RoomAvailabilityService(
            roomRepo.Object,
            bookingRepo.Object);

        var request = new SearchAvailabilityRequest
        {
            HotelId = hotelId,
            CheckIn = new DateOnly(2025, 1, 1),
            CheckOut = new DateOnly(2025, 1, 2),
            Guests = 1
        };

        // Act
        var result = await service.SearchAsync(request, default);

        // Assert
        result.Rooms.Should().HaveCount(1);
        result.Rooms.First().RoomNumber.Should().Be("101");
    }
}
