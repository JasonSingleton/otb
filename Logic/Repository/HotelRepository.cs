using System.Text.Json;
using Logic.Model;

namespace Logic.Repository;

public class HotelRepository : IHotelRepository
{
    private static readonly IEnumerable<Hotel> Hotels;

    static HotelRepository()
    {
        var data = File.ReadAllBytes("DataSet/hotel.json");
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        Hotels = JsonSerializer.Deserialize<IEnumerable<Hotel>>(data, options)!;

        if (Hotels == null)
        {
            throw new NotSupportedException("Hotel data missing");
        }
    }
    
    public ValueTask<int> TotalHotels()
    {
        return ValueTask.FromResult(Hotels.Count());
    }

    public Task<IEnumerable<Hotel>> FindHotels(string travelTo, DateTimeOffset departOn, int duration, CancellationToken cancellationToken)
    {
        var query = Hotels.Where(h =>
            h.LocalAirports.Contains(travelTo) && h.ArrivalDate == departOn.Date && h.Nights == duration);

        return Task.FromResult(query);
    }
    
}