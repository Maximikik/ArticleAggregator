using ArticleAggregator.Data.Entities;
using ArticleAggregator.Data;
using ArticleAggregator.Mapping;
using ArticleAggregator.Services.Interfaces;
using ArticleAggregator.Services;
using ArticleAggregator_Repositories.Interfaces;
using ArticleAggregator_Repositories.Repositories;
using ArticleAggregator_Repositories;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using System.Data;
using ArticleAggregator.Data.CQS.Articles.Commands;

namespace ArticleAggregator.Api;

public static class IServiceCollectionExtension
{
    public static void RegisterServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");
        services.AddDbContext<ArticlesAggregatorDbContext>(opt =>
            opt.UseSqlServer(connectionString));

        services.AddScoped<IRepository<Article>, Repository<Article>>();
        services.AddScoped<IRepository<Source>, Repository<Source>>();
        services.AddScoped<IRepository<Category>, Repository<Category>>();
        services.AddScoped<IRepository<SourceCategories>, Repository<SourceCategories>>();
        services.AddScoped<IRepository<Client>, Repository<Client>>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IArticleService, ArticleService>();
        //services.AddScoped<IUserService, UserService>();

        services.AddScoped<ArticleMapper>();

        services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(connectionString));

        services.AddHangfireServer();

        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(typeof(CreateArticleCommand).Assembly);
        });
    }
}
