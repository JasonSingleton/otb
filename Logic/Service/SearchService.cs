using Logic.Request;
using Logic.Response;

namespace Logic.Service;

public class SearchService : ISearchService
{
    public Task<SearchResponse> SearchAsync(SearchRequest request, CancellationToken cancellationToken = default)
    {
        return null!;
    }
}