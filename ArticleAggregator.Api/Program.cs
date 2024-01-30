using ArticleAggregator.Api;
using ArticleAggregator.Data;
using Hangfire;
using Serilog;
using Serilog.Events;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.RegisterServices(builder.Configuration);
builder.Services.ConfigureJwt(builder.Configuration);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<ArticlesAggregatorDbContext>();
    DbInitializer.Initialize(db);
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.UseHangfireDashboard();

app.MapControllers();

app.MapHangfireDashboard();

app.Run();