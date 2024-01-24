namespace ArticleAggregator.Core.Dto;

public class RoleDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Guid> ClientsId { get; set; } = null!;
}
