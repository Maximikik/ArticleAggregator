namespace ArticleAggregator.Core.Models;

public class RoleModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public List<ClientModel> Clients { get; set; } = null!;
}
