namespace ArticleAggregator.Core.Dto;

public class FeedDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public IEnumerable<ArticleDto> Articles { get; set; } = [];
}
