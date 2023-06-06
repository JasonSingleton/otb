using Logic.Model;
using Logic.Repository;

namespace Tests.Stubs;

public class HotelRepositoryStub : IHotelRepository
{
    private List<Hotel> _items = new ();
    
    public HotelRepositoryStub Add(Hotel flight)
    {
        _items.Add(flight);
        return this;
    }

    public ValueTask<int> TotalHotels()
    {
        return new ValueTask<int>(_items.Count);
    }

    public Task<IEnumerable<Hotel>> FindHotels(string travelTo, DateTimeOffset departOn, int duration, CancellationToken cancellationToken)
    {
        return Task.FromResult(_items.AsEnumerable());
    }
}