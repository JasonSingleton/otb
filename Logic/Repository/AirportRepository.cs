using Logic.Model;

namespace Logic.Repository;

public class AirportRepository : IAirportRepository
{
    private IEnumerable<Airport> _airports = new List<Airport>()
    {
        new("LGW", "LON"),
        new("LCY", "LON"),
        new("LHR", "LON"),
        new("STN", "LON"),
        new("LTN", "LON"),
        new("SEN", "LON"),
        new("YXU", "LON"),
        new("OXF", "LON"),
        new("EGLW", "LON"),
        new("MAN", ""),
        new("AGP", ""),
        new("PMI", ""),
        new("LPA", ""),
    };
    
    public ValueTask<bool> AirportGroupExists(string airportGroup, CancellationToken cancellationToken)
    {
        return ValueTask.FromResult(_airports.Any(a => a.GroupCode == airportGroup));
    }

    public ValueTask<bool> AirportExists(string airport, CancellationToken cancellationToken)
    {
        return ValueTask.FromResult(_airports.Any(a => a.AirportCode == airport));
    }

    public ValueTask<IEnumerable<string>> FetchAirportsFromGroup(string airportGroup, CancellationToken cancellationToken)
    {
        var result = _airports
            .Where(a => a.GroupCode == airportGroup)
            .Select(p => p.AirportCode);
        
        return ValueTask.FromResult(result);
    }
}