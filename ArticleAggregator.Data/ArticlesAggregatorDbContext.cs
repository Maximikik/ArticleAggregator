using ArticleAggregator.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data;

public class ArticlesAggregatorDbContext : DbContext
{
    public DbSet<Article> Articles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Source> Sources { get; set; }
    public DbSet<SourceCategories> SourceCategories { get; set; }

    public ArticlesAggregatorDbContext(DbContextOptions<ArticlesAggregatorDbContext> options)
        : base(options)
    {
    }
}
