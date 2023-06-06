using System.Text.Json;
using Logic.Model;

namespace Logic.Repository;

public class FlightRepository : IFlightRepository
{
    private static readonly IEnumerable<Flight> Flights;

    static FlightRepository()
    {
        var data = File.ReadAllBytes("DataSet/flight.json");
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        Flights = JsonSerializer.Deserialize<IEnumerable<Flight>>(data, options)!;

        if (Flights == null)
        {
            throw new NotSupportedException("Flight data missing");
        }
    }
    
    public ValueTask<int> TotalFlights()
    {
        return ValueTask.FromResult(Flights.Count());
    }
}