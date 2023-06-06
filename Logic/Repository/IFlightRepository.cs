namespace Logic.Repository;

public interface IFlightRepository
{
    ValueTask<int> TotalFlights();
}