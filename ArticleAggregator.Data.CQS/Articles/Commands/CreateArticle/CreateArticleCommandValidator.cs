using FluentValidation;

namespace ArticleAggregator.Data.CQS.Articles.Commands.CreateArticle;

public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
{
    public CreateArticleCommandValidator()
    {
        RuleFor(item => item.ArticleDto).NotNull();
        RuleFor(item => item.ArticleDto.SourceUrl).NotNull();
        RuleFor(item => item.ArticleDto.ArticleSourceId).NotEmpty();
        RuleFor(item => item.ArticleDto.Title).NotNull();
        RuleFor(item => item.ArticleDto.Description).NotNull();
    }
}
