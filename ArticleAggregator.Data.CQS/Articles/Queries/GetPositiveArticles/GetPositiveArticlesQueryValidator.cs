using ArticleAggregator.Data.CQS.Articles.Queries.GetPositive;
using FluentValidation;

namespace ArticleAggregator.Data.CQS.Articles.Queries.GetPositiveArticles;

public class GetPositiveArticlesQueryValidator : AbstractValidator<GetPositiveArticlesQuery>
{
    public GetPositiveArticlesQueryValidator()
    {
        RuleFor(item => item.rateGreaterThan).GreaterThan(0);
    }
}
