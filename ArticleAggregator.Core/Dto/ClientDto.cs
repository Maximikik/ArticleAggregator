namespace ArticleAggregator.Core.Dto;

public class ClientDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public Guid RoleId { get; set; }

    public List<Guid> FavouriteCategoriesId { get; set; }
}