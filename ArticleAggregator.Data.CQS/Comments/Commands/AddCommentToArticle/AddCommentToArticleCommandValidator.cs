using FluentValidation;

namespace ArticleAggregator.Data.CQS.Comments.Commands.AddCommentToArticle;

public class AddCommentToArticleCommandValidator : AbstractValidator<AddCommentToArticleCommand>
{
    public AddCommentToArticleCommandValidator()
    {
        RuleFor(item => item.CommentDto).NotNull();
        RuleFor(item => item.CommentDto.ChildComments).NotNull();
        RuleFor(item => item.CommentDto.Text).NotNull();
        RuleFor(item => item.CommentDto.ArticleId).NotEmpty();
        RuleFor(item => item.CommentDto.ClientId).NotEmpty();
        RuleFor(item => item.CommentDto.ParentCommentId).NotEmpty();
        RuleFor(item => item.CommentDto.Date).NotEmpty();
        RuleFor(item => item.CommentDto.Id).NotEmpty();
    }
}
