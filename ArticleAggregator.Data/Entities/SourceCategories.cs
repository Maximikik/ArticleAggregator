namespace ArticleAggregator.Data.Entities;

public class SourceCategories : IBaseEntity
{
    public Guid Id { get; set; }
    public Guid SourceId { get; set; }

    public virtual Source Source { get; set; } = null!;
    public virtual IEnumerable<Category>? Categories { get; set; }
}
