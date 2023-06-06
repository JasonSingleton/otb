using Logic.Request;
using Logic.Response;

namespace Logic.Service;

public interface ISearchService
{
    Task<SearchResponse> SearchAsync(SearchRequest request, CancellationToken cancellationToken = default);
}