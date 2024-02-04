using FluentValidation;

namespace ArticleAggregator.Data.CQS.Roles.Commands.DeleteRoleByName;

public class DeleteRoleByNameCommandValidator : AbstractValidator<DeleteRoleByNameCommand>
{
    public DeleteRoleByNameCommandValidator()
    {
        RuleFor(item => item.Name).NotNull();
    }
}
