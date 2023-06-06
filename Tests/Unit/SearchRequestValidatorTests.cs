using FluentValidation.TestHelper;
using Logic.Request;
using Tests.Builder;

namespace Tests.Unit;

public class SearchRequestValidatorTests
{
    [Test]
    public async Task Given_DepartFromAllAirport_ShouldNotHaveError()
    {
        // Arrange
        var validator = new SearchRequestValidatorBuilder().Build();
        var model = new SearchRequest()
        {
            DepartFrom = null
        };
            
        // Act
        var result = await validator.TestValidateAsync(model);
        
        // Assert
        result.ShouldNotHaveValidationErrorFor(p => p.DepartFrom);
    }
    
    [Test]
    public async Task Given_DepartFromLondonGroup_ShouldNotHaveError()
    {
        // Arrange
        var validator = new SearchRequestValidatorBuilder().Build();
        var model = new SearchRequest()
        {
            DepartFrom = "LON",
            AirportGroup = true
        };
            
        // Act
        var result = await validator.TestValidateAsync(model);
        
        // Assert
        result.ShouldNotHaveValidationErrorFor(p => p.DepartFrom);
    }
    
    [Test]
    public async Task Given_DepartFromInvalidGroup_ShouldHaveError()
    {
        // Arrange
        var validator = new SearchRequestValidatorBuilder().Build();
        var model = new SearchRequest()
        {
            DepartFrom = "???",
            AirportGroup = false
        };
            
        // Act
        var result = await validator.TestValidateAsync(model);
        
        // Assert
        result.ShouldHaveValidationErrorFor(p => p.DepartFrom);
    }

    [Test]
    public async Task Given_DepartFromLondonGroupGroupNotEnabled_ShouldHaveError()
    {
        // Arrange
        var validator = new SearchRequestValidatorBuilder().Build();
        var model = new SearchRequest()
        {
            DepartFrom = "LON",
            AirportGroup = false
        };
            
        // Act
        var result = await validator.TestValidateAsync(model);
        
        // Assert
        result.ShouldHaveValidationErrorFor(p => p.DepartFrom);
    }
    
    [Test]
    public async Task Given_DepartFromValidAirport_ShouldNotHaveError()
    {
        // Arrange
        var validator = new SearchRequestValidatorBuilder().Build();
        var model = new SearchRequest()
        {
            DepartFrom = "MAN"
        };
            
        // Act
        var result = await validator.TestValidateAsync(model);
        
        // Assert
        result.ShouldNotHaveValidationErrorFor(p => p.DepartFrom);
    }
    
    [Test]
    public async Task Given_DepartFromInValidAirport_ShouldHaveError()
    {
        // Arrange
        var validator = new SearchRequestValidatorBuilder().Build();
        var model = new SearchRequest()
        {
            DepartFrom = "???"
        };
            
        // Act
        var result = await validator.TestValidateAsync(model);
        
        // Assert
        result.ShouldHaveValidationErrorFor(p => p.DepartFrom);
    }
    
    [Test]
    public async Task Given_TravelToValidAirport_ShouldNotHaveError()
    {
        // Arrange
        var validator = new SearchRequestValidatorBuilder().Build();
        var model = new SearchRequest()
        { 
            TravelTo = "PMI"
        };
            
        // Act
        var result = await validator.TestValidateAsync(model);
        
        // Assert
        result.ShouldNotHaveValidationErrorFor(p => p.TravelTo);
    }
    
    [Test]
    public async Task Given_TravelToInvalidAirport_ShouldHaveError()
    {
        // Arrange
        var validator = new SearchRequestValidatorBuilder().Build();
        var model = new SearchRequest()
        {
            TravelTo = "???"
        };
            
        // Act
        var result = await validator.TestValidateAsync(model);
        
        // Assert
        result.ShouldHaveValidationErrorFor(p => p.TravelTo);
    }

    [Test]
    public async Task Given_DepartureDateInThePast_ShouldHaveError()
    {
        // Arrange
        var validator = new SearchRequestValidatorBuilder().Build();
        var model = new SearchRequest()
        {
            DepartOn = DateTimeOffset.Now.AddDays(-1)
        };
            
        // Act
        var result = await validator.TestValidateAsync(model);
        
        // Assert
        result.ShouldHaveValidationErrorFor(p => p.DepartOn);
    }
    
    [Test]
    public async Task Given_DurationIsLowerThan1_ShouldHaveError()
    {
        // Arrange
        var validator = new SearchRequestValidatorBuilder().Build();
        var model = new SearchRequest()
        { 
            Duration = 0
        };
            
        // Act
        var result = await validator.TestValidateAsync(model);
        
        // Assert
        result.ShouldHaveValidationErrorFor(p => p.Duration);
    }
}