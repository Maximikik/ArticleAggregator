using FluentValidation;

namespace ArticleAggregator.Data.CQS.Comments.Commands.RemoveCommentFromArticle;

public class RemoveCommentFromArticleCommandValidator : AbstractValidator<RemoveCommentFromArticleCommand>
{
    public RemoveCommentFromArticleCommandValidator()
    {
        RuleFor(item => item.CommentId).NotEmpty();
    }
}
