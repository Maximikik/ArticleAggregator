namespace ArticleAggregator.Core.Dto;

public class ArticleDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string SourceUrl { get; set; } = null!;
    public int? Rating { get; set; }
    public Guid ArticleSourceId { get; set; }
    public List<Guid> CategoriesId { get; set; } = null!;
}
