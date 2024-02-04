using FluentValidation;

namespace ArticleAggregator.Data.CQS.Sources.Queries.GetArticlesOfSourceById;

public class GetArticlesOfSourceByIdQueryValidator : AbstractValidator<GetArticlesOfSourceByIdQuery>
{
    public GetArticlesOfSourceByIdQueryValidator()
    {
        RuleFor(item => item.Id).NotEmpty();
    }
}
