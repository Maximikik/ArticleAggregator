using FluentValidation;

namespace ArticleAggregator.Data.CQS.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQueryValidator : AbstractValidator<GetAllCategoriesQuery>
{
    public GetAllCategoriesQueryValidator()
    { }
}
