namespace ArticleAggregator.Data.Entities;

public class Category : IBaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public double PositivityRating { get; set; }
}