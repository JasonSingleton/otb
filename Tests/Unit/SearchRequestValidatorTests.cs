using FluentValidation.TestHelper;
using Logic.Request;
using Logic.Validation;

namespace Tests.Unit;

public class SearchRequestValidatorTests
{
    [Test]
    public void Given_DepartFromAllAirport_ShouldNotHaveError()
    {
        // Arrange
        var validator  = new SearchRequestValidator();
        var model = new SearchRequest()
        {
            DepartFrom = null
        };
            
        // Act
        var result = validator.TestValidate(model);
        
        // Assert
        result.ShouldNotHaveValidationErrorFor(p => p.DepartFrom);
    }
    
    [Test]
    public void Given_DepartFromLondonGroup_ShouldNotHaveError()
    {
        // Arrange
        var validator  = new SearchRequestValidator();
        var model = new SearchRequest()
        {
            DepartFrom = "LON",
            AirportGroup = true
        };
            
        // Act
        var result = validator.TestValidate(model);
        
        // Assert
        result.ShouldNotHaveValidationErrorFor(p => p.DepartFrom);
    }
    
    [Test]
    public void Given_DepartFromInvalidGroup_ShouldHaveError()
    {
        // Arrange
        var validator  = new SearchRequestValidator();
        var model = new SearchRequest()
        {
            DepartFrom = "???",
            AirportGroup = false
        };
            
        // Act
        var result = validator.TestValidate(model);
        
        // Assert
        result.ShouldHaveValidationErrorFor(p => p.DepartFrom);
    }

    [Test]
    public void Given_DepartFromLondonGroupGroupNotEnabled_ShouldHaveError()
    {
        // Arrange
        var validator  = new SearchRequestValidator();
        var model = new SearchRequest()
        {
            DepartFrom = "LON",
            AirportGroup = false
        };
            
        // Act
        var result = validator.TestValidate(model);
        
        // Assert
        result.ShouldHaveValidationErrorFor(p => p.DepartFrom);
    }
    
    [Test]
    public void Given_DepartFromValidAirport_ShouldNotHaveError()
    {
        // Arrange
        var validator  = new SearchRequestValidator();
        var model = new SearchRequest()
        {
            DepartFrom = "MAN"
        };
            
        // Act
        var result = validator.TestValidate(model);
        
        // Assert
        result.ShouldNotHaveValidationErrorFor(p => p.DepartFrom);
    }
    
    [Test]
    public void Given_DepartFromInValidAirport_ShouldHaveError()
    {
        // Arrange
        var validator  = new SearchRequestValidator();
        var model = new SearchRequest()
        {
            DepartFrom = "???"
        };
            
        // Act
        var result = validator.TestValidate(model);
        
        // Assert
        result.ShouldHaveValidationErrorFor(p => p.DepartFrom);
    }
    
    [Test]
    public void Given_TravelToValidAirport_ShouldNotHaveError()
    {
        // Arrange
        var validator  = new SearchRequestValidator();
        var model = new SearchRequest()
        { 
            TravelTo = "PMI"
        };
            
        // Act
        var result = validator.TestValidate(model);
        
        // Assert
        result.ShouldNotHaveValidationErrorFor(p => p.TravelTo);
    }
    
    [Test]
    public void Given_TravelToInvalidAirport_ShouldHaveError()
    {
        // Arrange
        var validator  = new SearchRequestValidator();
        var model = new SearchRequest()
        {
            TravelTo = "???"
        };
            
        // Act
        var result = validator.TestValidate(model);
        
        // Assert
        result.ShouldHaveValidationErrorFor(p => p.TravelTo);
    }

    [Test]
    public void Given_DepartureDateInThePast_ShouldHaveError()
    {
        // Arrange
        var validator  = new SearchRequestValidator();
        var model = new SearchRequest()
        {
            DepartOn = DateTimeOffset.Now.AddDays(-1)
        };
            
        // Act
        var result = validator.TestValidate(model);
        
        // Assert
        result.ShouldHaveValidationErrorFor(p => p.DepartOn);
    }
    
    [Test]
    public void Given_DurationIsLowerThan1_ShouldHaveError()
    {
        // Arrange
        var validator  = new SearchRequestValidator();
        var model = new SearchRequest()
        { 
            Duration = 0
        };
            
        // Act
        var result = validator.TestValidate(model);
        
        // Assert
        result.ShouldHaveValidationErrorFor(p => p.Duration);
    }
}