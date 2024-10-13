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
    var settings = EventStoreClientSettings.Create("esdb://6055-190-113-111-32.ngrok-free.app");
   
    settings.DefaultCredentials = new UserCredentials("admin","changeit");


    return new EventStoreClient(settings);

});

builder.Services.AddScoped<IEventStoreService, EventStoreService>();
//https://e6bd-190-113-111-32.ngrok-free.app
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
var url = app.Urls.FirstOrDefault();
Console.WriteLine(url);

app.Run();
