using FluentValidation;

namespace ArticleAggregator.Data.CQS.Tokens.Commands.DeleteRefreshToken;

public class DeleteRefreshTokenCommandValidator : AbstractValidator<DeleteRefreshTokenCommand>
{
    public DeleteRefreshTokenCommandValidator()
    {
        RuleFor(item => item.Id).NotEmpty();
    }
}
