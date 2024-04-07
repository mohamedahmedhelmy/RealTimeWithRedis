using RealTimeServiceWithRedis.Hubs;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("Redis"));
builder.Services.AddControllers();
builder.Services.AddSignalR().AddStackExchangeRedis(options =>
{
    var redisConfig = builder.Configuration.GetConnectionString("Redis");
    options.Configuration = ConfigurationOptions.Parse(redisConfig);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.MapHub<MainHub>("main-hub");
app.Run();
