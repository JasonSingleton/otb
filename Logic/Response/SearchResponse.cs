using FluentValidation.Results;
using Logic.Model;

namespace Logic.Response;

public record SearchResponse
{
    public IEnumerable<SearchResult> Results { get; set; } = null!;
    public bool Complete { get; set; }
    public List<ValidationFailure> Errors { get; set; } = null!;
}