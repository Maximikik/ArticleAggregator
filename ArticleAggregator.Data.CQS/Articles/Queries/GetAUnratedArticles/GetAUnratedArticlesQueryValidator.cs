using FluentValidation;

namespace ArticleAggregator.Data.CQS.Articles.Queries.GetAUnratedArticles;

public class GetAUnratedArticlesQueryValidator : AbstractValidator<GetAUnratedArticlesQuery>
{
    public GetAUnratedArticlesQueryValidator()
    {
        RuleFor(item => item.MaxTake).GreaterThan(0).LessThan(100);
    }
}
