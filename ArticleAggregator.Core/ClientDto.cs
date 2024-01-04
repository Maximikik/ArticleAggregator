namespace ArticleAggregator.Core;

public class ClientDto
{
    public Guid Id { get; set; }
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;

    public virtual IEnumerable<Guid> FavouriteCategoriesId { get; set; }
}