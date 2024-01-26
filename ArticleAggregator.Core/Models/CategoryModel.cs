namespace ArticleAggregator.Core.Models;

public class CategoryModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public double PositivityRating { get; set; }
}
