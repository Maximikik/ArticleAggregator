using FluentValidation;

namespace ArticleAggregator.Data.CQS.Articles.Queries.GetArticleByName;

public class GetArticleByTitleQueryValidator : AbstractValidator<GetArticleByTitleQuery>
{
    public GetArticleByTitleQueryValidator()
    {
        RuleFor(item => item.ArticleTitle).NotNull();
    }
}
