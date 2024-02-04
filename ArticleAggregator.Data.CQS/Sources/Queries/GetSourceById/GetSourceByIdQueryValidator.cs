using FluentValidation;

namespace ArticleAggregator.Data.CQS.Sources.Queries.GetSourceById;

public class GetSourceByIdQueryValidator : AbstractValidator<GetSourceByIdQuery>
{
    public GetSourceByIdQueryValidator()
    {
        RuleFor(item => item.Id).NotEmpty();
    }
}
