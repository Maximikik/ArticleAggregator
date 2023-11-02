namespace ArticleAggregator.Data.Entities;

public class Article : IBaseEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public double Rating { get; set; }
    public Guid ArticleSourceId { get; set; }

    public virtual Source ArticleSource { get; set; }
}