using FluentValidation;

namespace ArticleAggregator.Data.CQS.Articles.Commands.InsertRssData;

public class InsertRssDataCommandValidator : AbstractValidator<InsertRssDataCommand>
{
    public InsertRssDataCommandValidator()
    {
        RuleFor(item => item.Articles).NotNull();
    }
}
