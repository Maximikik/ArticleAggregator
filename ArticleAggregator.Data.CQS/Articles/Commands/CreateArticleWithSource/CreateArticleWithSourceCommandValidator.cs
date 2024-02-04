using FluentValidation;

namespace ArticleAggregator.Data.CQS.Articles.Commands.CreateArticleWithSource;

public class CreateArticleWithSourceCommandValidator : AbstractValidator<CreateArticleWithSourceCommand>
{
    public CreateArticleWithSourceCommandValidator()
    {
        RuleFor(item => item.Title).NotNull();
        RuleFor(item => item.ArticleSourceId).NotEmpty();
        RuleFor(item => item.Rating).GreaterThan(0).LessThan(10);
    }
}
