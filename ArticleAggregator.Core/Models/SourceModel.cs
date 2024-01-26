namespace ArticleAggregator.Core.Models;

public class SourceModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string RssUrl { get; set; } = null!;
    public List<Guid> ArticlesId { get; set; } = null!;
}
