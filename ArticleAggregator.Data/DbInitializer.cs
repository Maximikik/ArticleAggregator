namespace ArticleAggregator.Data;

public static class DbInitializer
{
    public static void Initialize(ArticlesAggregatorDbContext context)
    {
        context.Database.EnsureCreated();
    }
}
