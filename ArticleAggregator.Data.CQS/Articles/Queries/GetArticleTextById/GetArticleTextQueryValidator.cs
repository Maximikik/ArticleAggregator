using ArticleAggregator.Data.CQS.Articles.Queries.GetArticleById;
using FluentValidation;

namespace ArticleAggregator.Data.CQS.Articles.Queries.GetArticleTextById;

public class GetArticleTextQueryValidator : AbstractValidator<GetArticleTextQuery>
{
    public GetArticleTextQueryValidator()
    {
        RuleFor(item => item.Id).NotEmpty();
    }
}
