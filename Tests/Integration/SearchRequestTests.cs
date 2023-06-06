using FluentAssertions;
using Logic.Request;
using Tests.Builder;

namespace Tests.Integration;

public class SearchServiceTests
{
    [Test]
    public async Task When_InvalidArguments_ShouldNotCompleteAndGiveValidationErrors()
    {
        // Arrange
        var sut = new SearchServiceBuilder().Build();
        var request = new SearchRequest();
        
        // Act
        var response = await sut.SearchAsync(request);

        // Assert
        response.Complete.Should().BeFalse();
        response.Errors.Should().NotBeEmpty();
    }
    
    [Test]
    public async Task When_ValidArguments_ShouldNotCompleteAndGiveValidationErrors()
    {
        // Arrange
        var sut = new SearchServiceBuilder().Build();
        var request = new SearchRequest
        {
            DepartFrom = "MAN",
            TravelTo = "LGW",
            DepartOn = DateTimeOffset.Now,
            Duration = 2
        };
        
        // Act
        var response = await sut.SearchAsync(request);

        // Assert
        response.Complete.Should().BeTrue();
        response.Errors.Should().BeEmpty();
    }
}