using FluentValidation;

namespace ArticleAggregator.Data.CQS.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(item => item.CategoryDto).NotNull();
    }
}
