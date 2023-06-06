namespace Logic.Repository;

public interface IHotelRepository
{
    ValueTask<int> TotalHotels();
}