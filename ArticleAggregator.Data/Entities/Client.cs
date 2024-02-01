namespace ArticleAggregator.Data.Entities;

public class Client : IBaseEntity
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public Guid RoleId { get; set; }
    public Role Role { get; set; } = null!;

    public virtual IEnumerable<Category> FavouriteCategories { get; set; } = null!;
}
