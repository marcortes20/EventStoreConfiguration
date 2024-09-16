using EventStore.Client;
using Services.EventStore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<EventStoreClient>(sp =>
{
    var settings =
    EventStoreClientSettings.Create("esdb://localhost:2113");
    settings.DefaultCredentials = new UserCredentials("admin",
    "changeit");
    return new EventStoreClient(settings);
});

builder.Services.AddScoped<IEventStoreService, EventStoreService>();

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
