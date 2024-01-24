namespace ArticleAggregator.Data.CustomExceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string entityName)
        : base($"Entity \"{entityName}\" not found.") { }

    public NotFoundException(string entityName, Guid id)
        : base($"Entity \"{entityName}\" ({id}) not found.") { }

    public NotFoundException(string entityName, string name)
        : base($"Entity \"{entityName}\" name: \"{name}\" not found.") { }
}
