
namespace ArticleAggregator.Data.Entities;

public class Role : IBaseEntity
{
    public Guid Id { get; set ; }
    public string Name { get; set; } = null!;
    public List<Client> Clients { get; set; } = null!;
}
