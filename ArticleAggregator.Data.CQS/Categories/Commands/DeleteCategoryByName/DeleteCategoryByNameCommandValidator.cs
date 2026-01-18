using FluentValidation;

namespace ArticleAggregator.Data.CQS.Categories.Commands.DeleteCategoryByName;

public class DeleteCategoryByNameCommandValidator : AbstractValidator<DeleteCategoryByNameCommand>
{
    public DeleteCategoryByNameCommandValidator()
    {
        RuleFor(item => item.Name).NotNull();
    }
}
