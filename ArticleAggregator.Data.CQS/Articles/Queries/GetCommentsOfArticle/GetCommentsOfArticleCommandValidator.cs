using ArticleAggregator.Data.CQS.Articles.Queries.GetArticleById;
using FluentValidation;

namespace ArticleAggregator.Data.CQS.Articles.Queries.GetCommentsOfArticle;

public class GetCommentsOfArticleCommandValidator : AbstractValidator<GetCommentsOfArticleQuery>
{
    public GetCommentsOfArticleCommandValidator()
    {
        RuleFor(item => item.Id).NotEmpty();
    }
}
