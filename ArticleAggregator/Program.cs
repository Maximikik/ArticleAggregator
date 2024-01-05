using ArticleAggregator.Data.Entities;
using ArticleAggregator.Data;
using Microsoft.EntityFrameworkCore;
using ArticleAggregator_Repositories;
using ArticleAggregator_Repositories.Interfaces;
using ArticleAggregator_Repositories.Repositories;
using Serilog.Events;
using Serilog;

//const string ConnectionString = "Data Source=SQL6031.site4now.net;Initial Catalog=db_aa223c_dbaggregator;User Id=db_aa223c_dbaggregator_admin;Password=qweasd123123";

var builder = WebApplication.CreateBuilder(args);

var ConnectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<ArticlesAggregatorDbContext>(opt =>
                opt.UseSqlServer(ConnectionString));
var logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .WriteTo
                .File("log\\log.txt", rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Information)
                .WriteTo.Console()
                .Enrich.FromLogContext()

                .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddScoped<IRepository<Article>, Repository<Article>>();
builder.Services.AddScoped<IRepository<Source>, Repository<Source>>();
builder.Services.AddScoped<IRepository<Client>, Repository<Client>>();
builder.Services.AddScoped<IRepository<Category>, Repository<Category>>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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

