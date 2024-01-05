
namespace ArticleAggregator.Data.Entities;

public class Comment : IBaseEntity
{
    public Guid Id { get; set; }

    public string Text { get; set; } = null!;
    public DateTime Date { get; set; }

    public Guid ArticleId { get; set; }
    public Article Article { get; set; } = null!;

    public Guid? ParentCommentId { get; set; }
    public virtual Comment ParentComment { get; set; } = null!;

    public virtual List<Comment> ChildComments { get; set; } = null!;

    public Guid ClientId { get; set; }
    public virtual Client Client { get; set; } = null!;
}
