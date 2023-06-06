using Logic.Model;

namespace Logic.Response;

public record SearchResponse
{
    public IEnumerable<SearchResult> Results { get; set; } = null!;
}