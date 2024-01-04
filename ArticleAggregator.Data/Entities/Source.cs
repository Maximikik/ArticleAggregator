namespace ArticleAggregator.Data.Entities;


public class Source : IBaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string RssUrl { get; set; } = null!;

    public virtual IEnumerable<Category> Categories { get; set; }
}
