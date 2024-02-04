using FluentValidation;

namespace ArticleAggregator.Data.CQS.Roles.Commands.CreateRole;

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(item => item.RoleDto).NotNull();
        RuleFor(item => item.RoleDto.Id).NotEmpty();
        RuleFor(item => item.RoleDto.ClientsId).NotNull();
        RuleFor(item => item.RoleDto.Name).NotNull();
    }
}
