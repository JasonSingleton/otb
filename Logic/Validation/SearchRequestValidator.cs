using FluentValidation;
using Logic.Repository;
using Logic.Request;

namespace Logic.Validation;

public class SearchRequestValidator : AbstractValidator<SearchRequest>
{
    public SearchRequestValidator(IAirportRepository airportRepository)
    {
        if (airportRepository == null)
        {
            throw new ArgumentNullException(nameof(airportRepository));
        }
        
        RuleFor(p => p.Duration).GreaterThan(0);
        RuleFor(p => p.DepartOn).GreaterThan(DateTimeOffset.Now).WithSeverity(Severity.Warning);
        
        When( p=> p.DepartFrom == null, () => { })
            .Otherwise(() =>
            {
                When(p => p.AirportGroup, () =>
                    {
                        RuleFor(p => p.DepartFrom)
                            .MustAsync(async (v, ct) => await airportRepository.AirportGroupExists(v!, ct))
                            .WithMessage("Invalid airport group specified");
                    })
                    .Otherwise(() =>
                    {
                        RuleFor(p => p.DepartFrom)
                            .MustAsync(async (v, ct) => await airportRepository.AirportExists(v!, ct))
                            .WithMessage("Invalid airport group specified");
                    });
            });

        RuleFor(p => p.TravelTo).MustAsync(async (v, ct) => await airportRepository.AirportExists(v, ct));
    }
}