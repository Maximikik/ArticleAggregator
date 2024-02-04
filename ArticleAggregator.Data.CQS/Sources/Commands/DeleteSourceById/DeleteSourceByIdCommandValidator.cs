using FluentValidation;

namespace ArticleAggregator.Data.CQS.Sources.Commands.DeleteSourceById;

public class DeleteSourceByIdCommandValidator : AbstractValidator<DeleteSourceByIdCommand>
{
    public DeleteSourceByIdCommandValidator()
    {
        RuleFor(item => item.Id).NotEmpty();
    }
}
