namespace ArticleAggregator.Data.Entities;

public class Feed : IBaseEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;

    public IEnumerable<Article>? Articles { get; set; }
}
