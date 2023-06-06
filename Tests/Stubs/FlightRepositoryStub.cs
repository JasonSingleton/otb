using Logic.Model;
using Logic.Repository;

namespace Tests.Stubs;

public class FlightRepositoryStub : IFlightRepository
{
    private readonly List<Flight> _items = new ();
    
    public ValueTask<int> TotalFlights()
    {
        return new ValueTask<int>(_items.Count);
    }

    public FlightRepositoryStub Add(Flight flight)
    {
        _items.Add(flight);
        return this;
    }
    
    public ValueTask<IEnumerable<Flight>> FindFights(IEnumerable<string>? airport, DateTimeOffset departOn, string travelTo,
        CancellationToken cancellationToken)
    {
        return new ValueTask<IEnumerable<Flight>>(_items);
    }
}