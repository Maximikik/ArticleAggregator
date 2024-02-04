using FluentValidation;

namespace ArticleAggregator.Data.CQS.Clients.Queries.GetClientByRefreshToken;

public class GetClientByRefreshTokenQueryValidator : AbstractValidator<GetClientByRefreshTokenQuery>
{
    public GetClientByRefreshTokenQueryValidator()
    {
        RuleFor(item => item.RefreshTokenId).NotEmpty();
    }
}
