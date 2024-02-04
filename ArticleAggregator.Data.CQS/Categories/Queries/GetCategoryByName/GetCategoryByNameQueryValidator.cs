using FluentValidation;

namespace ArticleAggregator.Data.CQS.Categories.Queries.GetCategoryByName;

public class GetCategoryByNameQueryValidator : AbstractValidator<GetCategoryByNameQuery>
{
    public GetCategoryByNameQueryValidator()
    {
        RuleFor(item => item.Name).NotNull();
    }
}
