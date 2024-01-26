namespace ArticleAggregator.Core.Models;

public class ClientModel
{
    public Guid Id { get; set; }
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
}
