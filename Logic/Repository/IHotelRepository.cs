using Logic.Model;

namespace Logic.Repository;

public interface IHotelRepository
{
    ValueTask<int> TotalHotels();
    Task<IEnumerable<Hotel>> FindHotels(string travelTo, DateTimeOffset departOn, int duration, CancellationToken cancellationToken);
}