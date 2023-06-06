using FluentAssertions;
using Logic.Repository;

namespace Tests.Integration;

public class RepositoryInitializationTests
{

    [Test]
    public async Task FlightsRepository_ShouldContainData()
    {
        // Arrange
        var sut = new FlightRepository();
        
        // Act
        var count = await sut.TotalFlights();
        
        // Assert
        count.Should().BeGreaterThan(0);
    }
    
    [Test]
    public async Task HotelRepository_ShouldContainData()
    {
        // Arrange
        var sut = new HotelRepository();
        
        // Act
        var count = await sut.TotalHotels();
        
        // Assert
        count.Should().BeGreaterThan(0);
    } 

}