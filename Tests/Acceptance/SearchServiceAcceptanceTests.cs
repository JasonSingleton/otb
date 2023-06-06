using FluentAssertions;
using Logic.Request;
using Tests.Builder;

namespace Tests.Acceptance;

public class SearchServiceAcceptanceTests
{
    [Test]
    public async Task Given_Customer1Search_ShouldReturn_Flight2AndHotel9()
    {
        // Arrange
        var sut = new SearchServiceBuilder().Build();
        var request = new SearchRequest()
        {
            DepartFrom = "MAN",
            TravelTo = "AGP",
            DepartOn = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero),
            Duration = 7
        };
        
        // Act
        var response  = await sut.SearchAsync(request);
        var bestMatch = response.Results.FirstOrDefault();
        
        // Assert
        bestMatch.Should().NotBeNull();
        bestMatch!.FlightId.Should().Be(2);
        bestMatch.HotelId.Should().Be(9);
    }
    
    [Test]
    public async Task Given_Customer2Search_ShouldReturn_Flight6AndHotel5()
    {
        // Arrange
        var sut = new SearchServiceBuilder().Build();
        var request = new SearchRequest()
        {
            DepartFrom = "LON",
            AirportGroup = true,
            TravelTo = "PMI",
            DepartOn = new DateTimeOffset(2023, 6, 15, 0, 0, 0, TimeSpan.Zero),
            Duration = 10
        };
        
        // Act
        var response  = await sut.SearchAsync(request);
        var bestMatch = response.Results.FirstOrDefault();
        
        // Assert
        bestMatch.Should().NotBeNull();
        bestMatch!.FlightId.Should().Be(6);
        bestMatch.HotelId.Should().Be(5);
    }
    
    [Test]
    public async Task Given_Customer3Search_ShouldReturn_Flight7AndHotel6()
    {
        // Arrange
        var sut = new SearchServiceBuilder().Build();
        var request = new SearchRequest()
        {
            DepartFrom = null,
            TravelTo = "LPA",
            DepartOn = new DateTimeOffset(2022, 11, 10, 0, 0, 0, TimeSpan.Zero),
            Duration = 14
        };
        
        // Act
        var response  = await sut.SearchAsync(request);
        var bestMatch = response.Results.FirstOrDefault();
        
        // Assert
        bestMatch.Should().NotBeNull();
        bestMatch!.FlightId.Should().Be(7);
        bestMatch.HotelId.Should().Be(6);
    }
}
