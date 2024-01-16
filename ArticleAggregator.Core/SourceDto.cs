namespace ArticleAggregator.Core;

public class SourceDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string RssUrl { get; set; } = null!;

    public IEnumerable<Guid> ArticlesId { get; set; }
}
