using FluentValidation;

namespace ArticleAggregator.Data.CQS.Roles.Commands.UpdateRoleById;

public class UpdateRoleByIdCommandValidator : AbstractValidator<UpdateRoleByIdCommand>
{
    public UpdateRoleByIdCommandValidator()
    {
        RuleFor(item => item.Id).NotEmpty();
        RuleFor(item => item.Name).NotNull();
    }
}
