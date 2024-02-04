using FluentValidation;

namespace ArticleAggregator.Data.CQS.Articles.Commands.UpdateArticleText;

public class UpdateArticleTextCommandValidator : AbstractValidator<UpdateArticleTextCommand>
{
    public UpdateArticleTextCommandValidator()
    {
        RuleFor(item => item.ArticlesData).NotNull();
    }
}
