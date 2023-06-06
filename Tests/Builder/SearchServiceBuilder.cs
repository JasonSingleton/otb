using Logic.Service;

namespace Tests.Builder;

public class SearchServiceBuilder
{

    public ISearchService Build()
    {
        return new SearchService();
    }
}