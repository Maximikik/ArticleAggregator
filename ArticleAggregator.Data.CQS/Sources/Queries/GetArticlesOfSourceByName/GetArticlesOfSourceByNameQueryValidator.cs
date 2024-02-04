using FluentValidation;

namespace ArticleAggregator.Data.CQS.Sources.Queries.GetArticlesOfSourceByName;

public class GetArticlesOfSourceByNameQueryValidator : AbstractValidator<GetArticlesOfSourceByNameQuery>
{
    public GetArticlesOfSourceByNameQueryValidator()
    {
        RuleFor(item => item.Name).NotNull();
    }
}
