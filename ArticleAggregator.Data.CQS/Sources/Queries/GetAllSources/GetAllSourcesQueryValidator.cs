using FluentValidation;

namespace ArticleAggregator.Data.CQS.Sources.Queries.GetAllSources;

public class GetAllSourcesQueryValidator : AbstractValidator<GetAllSourcesQuery>
{
    public GetAllSourcesQueryValidator()
    { }
}
