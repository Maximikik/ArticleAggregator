using FluentValidation;

namespace ArticleAggregator.Data.CQS.Sources.Queries.GetSourceByName;

public  class GetSourceByNameQueryValidator : AbstractValidator<GetSourceByNameQuery>
{
    public GetSourceByNameQueryValidator()
    {
        RuleFor(item => item.Name).NotNull();
    }
}
