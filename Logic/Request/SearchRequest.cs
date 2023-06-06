namespace Logic.Request;

public record SearchRequest
{
    public string? DepartFrom { get; set; }
    public string TravelTo { get; set; } = null!;
    public DateTimeOffset DepartOn { get; set; }
    public int Duration { get; set; }
    public bool AirportGroup { get; set; }
}