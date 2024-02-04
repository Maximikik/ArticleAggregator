using FluentValidation;

namespace ArticleAggregator.Data.CQS.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery>
{
    public GetCategoryByIdQueryValidator()
    {
        RuleFor(item => item.Id).NotEmpty();
    }
}
