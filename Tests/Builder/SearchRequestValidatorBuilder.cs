using Logic.Repository;
using Logic.Validation;

namespace Tests.Builder;

public class SearchRequestValidatorBuilder
{
    public SearchRequestValidator Build()
    {
        return new SearchRequestValidator(new AirportRepository());
    }
}