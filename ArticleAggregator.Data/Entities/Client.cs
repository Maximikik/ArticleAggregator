namespace ArticleAggregator.Data.Entities;

public class Client : IBaseEntity
{
    public Guid Id { get; set; }
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;

    public virtual IEnumerable<Category> FavouriteCategories { get; set; }
}
