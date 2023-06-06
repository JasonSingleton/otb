using FluentAssertions;
using Logic.Request;
using Tests.Builder;
using Tests.Stubs;

namespace Tests.Unit;

public class SearchServiceTests
{
    [Test]
    public async Task When_ValidArguments_TotalCostShouldBeAscending()
    {
        // Arrange
        var flights = new FlightRepositoryStub()
            .Add(new() { Price = 1000 })
            .Add(new() { Price = 500 });

        var hotels = new HotelRepositoryStub()
            .Add(new() { PricePerNight = 100 })
            .Add(new() { PricePerNight= 50 });

        var sut = new SearchServiceBuilder()
            .WithFlights(flights)
            .WithHotels(hotels)
            .Build();

        var request = new SearchRequest()
        {
            DepartFrom = "LON",
            AirportGroup = true,
            TravelTo = "PMI",
            DepartOn = new DateTimeOffset(2023, 6, 15, 0, 0, 0, TimeSpan.Zero),
            Duration = 10
        };
        
        // Act
        var response = await sut.SearchAsync(request);
        var totals = response.Results.Select(r => r.TotalCost);
        
        // Assert
        totals.Should().BeInAscendingOrder();
    }
}