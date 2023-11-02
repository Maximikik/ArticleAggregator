using ArticleAggregator.Data.Entities;
using ArticleAggregator.Data;
using Microsoft.EntityFrameworkCore;
using ArticleAggregator_Repositories;
using ArticleAggregator_Repositories.Interfaces;
using ArticleAggregator_Repositories.Repositories;

const string ConnectionString = "Server=localhost\\SQLEXPRESS;Database=ArticlesAggregator;Trusted_Connection=true;Encrypt=false;TrustServerCertificate=false";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ArticlesAggregatorDbContext>(opt =>
                opt.UseSqlServer(ConnectionString));

//builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
//builder.Services.AddScoped<IArticleSourceRepository, ArticleSourceRepository>();

builder.Services.AddScoped<IRepository<Article>, Repository<Article>>();
builder.Services.AddScoped<IRepository<Source>, Repository<Source>>();
builder.Services.AddScoped<IRepository<Client>, Repository<Client>>();
builder.Services.AddScoped<IRepository<Category>, Repository<Category>>();
builder.Services.AddScoped<IRepository<SourceCategories>, Repository<SourceCategories>>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();

    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<ArticlesAggregatorDbContext>();
    DbInitializer.Initialize(db);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

