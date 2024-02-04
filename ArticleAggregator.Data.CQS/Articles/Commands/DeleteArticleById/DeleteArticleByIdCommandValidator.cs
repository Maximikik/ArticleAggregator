using FluentValidation;

namespace ArticleAggregator.Data.CQS.Articles.Commands.DeleteArticleById;

public class DeleteArticleByIdCommandValidator : AbstractValidator<DeleteArticleByIdCommand>
{
    public DeleteArticleByIdCommandValidator()
    {
        RuleFor(item => item.ArticleId).NotEmpty();
    }
}
