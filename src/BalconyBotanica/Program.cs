using System.Text.Json.Serialization;
using BalconyBotanica.Adapters.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(); // Voeg de MVC services toe
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

    options.JsonSerializerOptions.DefaultIgnoreCondition =
        JsonIgnoreCondition.WhenWritingNull;
});


builder.Services.AddScoped<PlantRepository>();

var app = builder.Build();
app.UseFileServer();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles(); //  statische bestanden te serveren
app.MapControllers(); // Map controllers
app.MapFallbackToFile("/index.html"); // index.html wordt getoond voor niet-specifieke routes


app.Run();