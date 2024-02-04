using FluentValidation;

namespace ArticleAggregator.Data.CQS.Articles.Queries.GetArticleById;

public class GetArticleByIdQueryValidator : AbstractValidator<GetArticleByIdQuery>
{
    public GetArticleByIdQueryValidator()
    {
        RuleFor(item => item.Id).NotEmpty();
    }
}
