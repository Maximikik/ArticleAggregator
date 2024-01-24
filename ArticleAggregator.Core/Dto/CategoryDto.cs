namespace ArticleAggregator.Core.Dto;

public class CategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public double PositivityRating { get; set; }
}
