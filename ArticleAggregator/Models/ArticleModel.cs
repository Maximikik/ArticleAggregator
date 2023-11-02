namespace ArticleAggregator.Models;

public class ArticleModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public double Rating { get; set; }
    public Guid ArticleSourceId { get; set; }
}
