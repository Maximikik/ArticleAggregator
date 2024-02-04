using FluentValidation;

namespace ArticleAggregator.Data.CQS.Clients.Queries.GetClientByLogin;

public class GetClientByLoginQueryValidator: AbstractValidator<GetClientByLoginQuery>
{
    public GetClientByLoginQueryValidator()
    {
        RuleFor(item => item.Login).NotNull();
    }
}
