using Logic.Repository;
using Logic.Service;
using Logic.Validation;

namespace Tests.Builder;

public class SearchServiceBuilder
{

    public ISearchService Build()
    {
        var airportRepository = new AirportRepository();
        return new SearchService(new FlightRepository(), new HotelRepository(), airportRepository,  new SearchRequestValidator(airportRepository));
    }
}