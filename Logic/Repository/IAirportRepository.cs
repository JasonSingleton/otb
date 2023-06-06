namespace Logic.Repository;

public interface IAirportRepository
{
    ValueTask<bool> AirportGroupExists(string airportGroup, CancellationToken cancellationToken);
    ValueTask<bool> AirportExists(string airport, CancellationToken cancellationToken);

    ValueTask<IEnumerable<string>> FetchAirportsFromGroup(string airportGroup, CancellationToken cancellationToken);

}