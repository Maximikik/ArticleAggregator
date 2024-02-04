using FluentValidation;

namespace ArticleAggregator.Data.CQS.Tokens.Commands.AddRefreshToken;

public class AddRefreshTokenCommandValidator : AbstractValidator<AddRefreshTokenCommand>
{
    public AddRefreshTokenCommandValidator()
    {
        RuleFor(item => item.ClientId).NotEmpty();
        RuleFor(item => item.Ip).NotNull();
    }
}
