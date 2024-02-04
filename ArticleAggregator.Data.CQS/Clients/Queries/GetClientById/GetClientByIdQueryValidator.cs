using FluentValidation;

namespace ArticleAggregator.Data.CQS.Clients.Queries.GetClientById;

public class GetClientByIdQueryValidator : AbstractValidator<GetClientByIdQuery>
{
    public GetClientByIdQueryValidator()
    {
        RuleFor(item => item.Id).NotEmpty();
    }
}
