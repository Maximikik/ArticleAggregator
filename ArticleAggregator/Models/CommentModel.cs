using ArticleAggregator.Data.Entities;

namespace ArticleAggregator.Models;

public class CommentModel
{
    public Guid Id { get; set; }

    public string Text { get; set; } = null!;
    public DateTime Date { get; set; }

    public Guid ArticleId { get; set; }
    public Article Article { get; set; } = null!;

    public Guid? ParentCommentId { get; set; }

    public List<Guid> ChildCommentsId { get; set; } = null!;

    public Guid ClientId { get; set; }
}
