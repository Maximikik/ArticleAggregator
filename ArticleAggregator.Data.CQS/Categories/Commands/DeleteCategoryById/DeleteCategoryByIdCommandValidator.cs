using FluentValidation;

namespace ArticleAggregator.Data.CQS.Categories.Commands.DeleteCategoryById;

public class DeleteCategoryByIdCommandValidator : AbstractValidator<DeleteCategoryByIdCommand>
{
    public DeleteCategoryByIdCommandValidator()
    {
        RuleFor(item => item.Id).NotEmpty();
    }
}
