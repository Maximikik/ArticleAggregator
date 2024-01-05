using ArticleAggregator.Data.Entities;

namespace ArticleAggregator.Models;

public class RoleModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Client> Clients { get; set; } = null!;
}
