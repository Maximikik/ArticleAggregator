using FluentValidation;

namespace ArticleAggregator.Data.CQS.Tokens.Queries.GetRefreshToken;

public class GetRefreshTokenQueryValidator : AbstractValidator<GetRefreshTokenQuery>
{
    public GetRefreshTokenQueryValidator()
    {
        RuleFor(item => item.Id).NotEmpty();
    }
}