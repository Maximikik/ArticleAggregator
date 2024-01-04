using ArticleAggregator.Api;
using Hangfire;
using Serilog;
using Serilog.Events;

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

builder.Configuration.AddJsonFile("AFINN-ru.json");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();
app.MapHangfireDashboard();


app.Run();
  