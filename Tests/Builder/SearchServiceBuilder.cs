using Logic.Repository;
using Logic.Service;
using Logic.Validation;

namespace Tests.Builder;

public class SearchServiceBuilder
{
    private IFlightRepository _flightRepository = new FlightRepository();
    private IHotelRepository _hotelRepository = new HotelRepository();

    public SearchServiceBuilder WithFlights(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
        return this;
    }
    
    public SearchServiceBuilder WithHotels(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
        return this;
    }

    public ISearchService Build()
    {
        var airportRepository = new AirportRepository();
        return new SearchService(_flightRepository, _hotelRepository, airportRepository,  new SearchRequestValidator(airportRepository));
    }
}