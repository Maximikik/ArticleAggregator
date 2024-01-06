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
using ArticleAggregator.Data.CQS.Roles.Commands;
using ArticleAggregator.Data.CQS.Roles.Queries;
using ArticleAggregator.Data.CQS.Sources.Commands;
using ArticleAggregator.Data.CQS.Sources.Queries;
using ArticleAggregator.Data.CQS.Articles.Queries;
using ArticleAggregator.Data.CQS.Categories.Commands;
using ArticleAggregator.Data.CQS.Categories.Queries;
using ArticleAggregator.Data.CQS.Comments.Commands;
using ArticleAggregator.Data.CQS.Articles.Handlers.Commands;
using ArticleAggregator.Data.CQS.Articles.Handlers.Queries;

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
        services.AddScoped<IRepository<Comment>, Repository<Comment>>();
        services.AddScoped<IRepository<Role>, Repository<Role>>();
        services.AddScoped<IRepository<Client>, Repository<Client>>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IArticleService, ArticleService>();
        services.AddScoped<ISourceService, SourceService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IRoleService, RoleService>();
        //services.AddScoped<IUserService, UserService>();

        services.AddScoped<ArticleMapper>();
        services.AddScoped<CategoryMapper>();
        services.AddScoped<ClientMapper>();
        services.AddScoped<SourceMapper>();
        services.AddScoped<CommentMapper>();
        services.AddScoped<RoleMapper>();

        services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(connectionString));

        services.AddHangfireServer();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(CreateArticleCommand).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(CreateArticleCommandHandler).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(GetArticleByIdQuery).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(GetArticleByIdQueryHandler).Assembly);
            //cfg.RegisterServicesFromAssembly(typeof(CreateArticleWithSourceCommand).Assembly);
            //cfg.RegisterServicesFromAssembly(typeof(DeleteArticleByIdCommand).Assembly);
            //cfg.RegisterServicesFromAssembly(typeof(InsertRssDataCommand).Assembly);
            //cfg.RegisterServicesFromAssembly(typeof(SetArticleRateCommand).Assembly);
            //cfg.RegisterServicesFromAssembly(typeof(UpdateArticleTextCommand).Assembly);

            //cfg.RegisterServicesFromAssembly(typeof(CreateRoleCommand).Assembly);
            //cfg.RegisterServicesFromAssembly(typeof(DeleteRoleByIdCommand).Assembly);
            //cfg.RegisterServicesFromAssembly(typeof(DeleteRoleByNameCommand).Assembly);
            //cfg.RegisterServicesFromAssembly(typeof(UpdateRoleByIdCommand).Assembly);
            //cfg.RegisterServicesFromAssembly(typeof(GetAllRolesQuery).Assembly);
            //cfg.RegisterServicesFromAssembly(typeof(GetRoleByNameQuery).Assembly);

            //cfg.RegisterServicesFromAssembly(typeof(CreateSourceCommand).Assembly);
            //cfg.RegisterServicesFromAssembly(typeof(DeleteSourceByIdCommand).Assembly);
            //cfg.RegisterServicesFromAssembly(typeof(GetAllSourcesQuery).Assembly);
            //cfg.RegisterServicesFromAssembly(typeof(GetArticlesOfSourceByIdQuery).Assembly);
            //cfg.RegisterServicesFromAssembly(typeof(GetArticlesOfSourceByNameQuery).Assembly);
            //cfg.RegisterServicesFromAssembly(typeof(GetSourceByIdQuery).Assembly);
            //cfg.RegisterServicesFromAssembly(typeof(GetSourceByNameQuery).Assembly);

            //cfg.RegisterServicesFromAssembly(typeof(GetArticleByIdQuery).Assembly);
            //cfg.RegisterServicesFromAssembly(typeof(GetArticleTextQuery).Assembly);
            //cfg.RegisterServicesFromAssembly(typeof(GetAUnratedArticlesQuery).Assembly);

            //cfg.RegisterServicesFromAssembly(typeof(CreateCategoryCommand).Assembly);
            //cfg.RegisterServicesFromAssembly(typeof(DeleteCategoryByIdCommand).Assembly);
            //cfg.RegisterServicesFromAssembly(typeof(DeleteCategoryByNameCommand).Assembly);
            //cfg.RegisterServicesFromAssembly(typeof(GetAllCategoriesQuery).Assembly);
            //cfg.RegisterServicesFromAssembly(typeof(GetCategoryByIdQuery).Assembly);
            //cfg.RegisterServicesFromAssembly(typeof(GetCategoryByNameQuery).Assembly);

            //cfg.RegisterServicesFromAssembly(typeof(AddCommentToArticleCommand).Assembly);
            //cfg.RegisterServicesFromAssembly(typeof(RemoveCommentFromArticleCommand).Assembly);
        });


    }
}
