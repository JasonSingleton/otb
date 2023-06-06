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

        // TODO: Perform actual searches
        
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