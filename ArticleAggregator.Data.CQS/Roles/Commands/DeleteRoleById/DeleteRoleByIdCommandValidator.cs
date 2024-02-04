using FluentValidation;

namespace ArticleAggregator.Data.CQS.Roles.Commands.DeleteRoleById;

public class DeleteRoleByIdCommandValidator : AbstractValidator<DeleteRoleByIdCommand>
{
    public DeleteRoleByIdCommandValidator()
    {
        RuleFor(item => item.Id).NotEmpty();
    }
}
