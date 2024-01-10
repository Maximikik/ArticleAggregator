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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

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
        services.AddScoped<ITokenService, TokenService>();
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

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "PFS.WebApi", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = JwtBearerDefaults.AuthenticationScheme
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        Array.Empty<string>()
                    }
                });
        });

        services.AddHangfireServer();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(CreateArticleCommand).Assembly);
        });


    }
}
