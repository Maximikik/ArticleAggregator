using ArticleAggregator.Api.Controllers;
using ArticleAggregator.Data;
using ArticleAggregator.Data.CQS.Articles.Commands.CreateArticle;
using ArticleAggregator.Data.Entities;
using ArticleAggregator.Mapping;
using ArticleAggregator.Services;
using ArticleAggregator.Services.Interfaces;
using ArticleAggregator_Repositories;
using ArticleAggregator_Repositories.Interfaces;
using ArticleAggregator_Repositories.Repositories;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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

        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<ISourceRepository, SourceRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IArticleService, ArticleService>();
        services.AddScoped<ISourceService, SourceService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<ITokenService, TokenService>();

        services.AddScoped<RssReader>();

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
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "GNA", Version = "v1" });
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

    public static void ConfigureJwt
        (this IServiceCollection services, IConfiguration configuration)
    {
        var issuer = configuration["Jwt:Issuer"];
        var audience = configuration["Jwt:Audience"];
        var secret = configuration["Jwt:Secret"]!;


        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),

                };
            });

        services.AddAuthorization();
    }
}
