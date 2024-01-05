namespace ArticleAggregator.Core;

public class CommentDto
{
    public Guid Id { get; set; }

    public string Text { get; set; } = null!;
    public DateTime Date { get; set; }

    public Guid ArticleId { get; set; }

    public Guid? ParentCommentId { get; set; }

    public List<CommentDto> ChildComments { get; set; } = null!;

    public Guid ClientId { get; set; }
}
