using Microsoft.Extensions.Options;
using Netflix_Imdb.Application.Ports.Interfaces;
using Netflix_Imdb.Application.Services.Interfaces;
using Netflix_Imdb.Application.Services;
using Netflix_Imdb.Infrastructure.Configuration;
using Netflix_Imdb.Infrastructure.Persistence;
using Netflix_Imdb.Infrastructure.Repositories;
using Netflix_Imdb.Infrastructure.RedisCache;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar MongoDBSettings
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"), true);
    return ConnectionMultiplexer.Connect(configuration);
});
builder.Services.AddScoped<IRedisCache, RedisCache>();

// Configurar MongoDB
builder.Services.AddSingleton<MongoDbContext>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDBSettings>>().Value;
    return new MongoDbContext(settings.ConnectionString, settings.DatabaseName);
});

// Configurar repositorios y servicios
builder.Services.AddScoped<ITitleRepository, TitleRepository>();
builder.Services.AddScoped<ITitleService, TitleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

