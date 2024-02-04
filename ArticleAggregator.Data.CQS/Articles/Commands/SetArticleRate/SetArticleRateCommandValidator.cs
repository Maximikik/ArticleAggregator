using FluentValidation;

namespace ArticleAggregator.Data.CQS.Articles.Commands.SetArticleRate;

public class SetArticleRateCommandValidator : AbstractValidator<SetArticleRateCommand>
{
    public SetArticleRateCommandValidator()
    {
        RuleFor(item => item.Id).NotEmpty();
        RuleFor(item => item.Rate).GreaterThan(0).LessThan(10);
    }
}
