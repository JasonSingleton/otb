using Logic.Model;

namespace Logic.Repository;

public interface IFlightRepository
{
    ValueTask<int> TotalFlights();
    ValueTask<IEnumerable<Flight>> FindFights(IEnumerable<string>? airport, DateTimeOffset departOn, string travelTo, CancellationToken cancellationToken);
}