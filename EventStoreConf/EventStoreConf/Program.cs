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
    try
    {
    var settings = EventStoreClientSettings.Create("esdb://admin:changeit@26.182.137.135:2113?tls=false&tlsVerifyCert=false");
   
   // settings.DefaultCredentials = new UserCredentials("admin","changeit");
     


        return new EventStoreClient(settings);
    }
    catch (Exception ex)
    {
        // Manejo de errores aquí
        Console.WriteLine($"Error al crear EventStoreClient: {ex.Message}");
        throw; // O manejarlo según sea necesario
    }



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
