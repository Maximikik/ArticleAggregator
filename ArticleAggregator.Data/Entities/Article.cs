namespace ArticleAggregator.Data.Entities;

public class Article : IBaseEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int? Rating { get; set; }
    public Guid ArticleSourceId { get; set; }

    public virtual Source ArticleSource { get; set; } = null!;
    public virtual List<Category> Categories { get; set; } = null!;
}