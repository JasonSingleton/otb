using FluentValidation;
using Logic.Model;
using Logic.Repository;
using Logic.Request;
using Logic.Response;
using Logic.Validation;

namespace Logic.Service;

public class SearchService : ISearchService
{
    private readonly IFlightRepository _flightRepository;
    private readonly IHotelRepository _hotelRepository;
    private readonly IAirportRepository _airportRepository;
    private readonly SearchRequestValidator _searchRequestValidator;

    public SearchService(IFlightRepository flightRepository, IHotelRepository hotelRepository, IAirportRepository airportRepository, SearchRequestValidator searchRequestValidator)
    {
        _flightRepository = flightRepository;
        _hotelRepository = hotelRepository;
        _airportRepository = airportRepository;
        _searchRequestValidator = searchRequestValidator;
    }
    public async Task<SearchResponse> SearchAsync(SearchRequest request, CancellationToken cancellationToken = default)
    {
        var response = new SearchResponse();
        if (await ValidateSearchRequest(request, response, cancellationToken))
        {
            return response;
        }

        var airports = await _airportRepository.DetermineAirports(request.DepartFrom, request.AirportGroup, cancellationToken);
        var flights = await _flightRepository.FindFights(airports, request.DepartOn, request.TravelTo, cancellationToken);
        var hotels = await _hotelRepository.FindHotels(request.TravelTo, request.DepartOn, request.Duration, cancellationToken);

        response.Results = (from f in flights.OrderBy(f => f.Price)
            from h in hotels.OrderBy(h => h.PricePerNight)
            select new SearchResult
            {
                FlightId = f.Id,
                HotelId = h.Id,
                TotalCost = f.Price + (h.PricePerNight * request.Duration)
            }).OrderBy(p => p.TotalCost);
        
        response.Complete = true;
        return response;
    }

    private async Task<bool> ValidateSearchRequest(SearchRequest request,SearchResponse response, CancellationToken cancellationToken)
    {
        var result = await _searchRequestValidator.ValidateAsync(request, cancellationToken);
        response.Errors = result.Errors;

        if (result.Errors.All(r => r.Severity != Severity.Error))
        {
            return false;
        }
        
        return true;
    }
}