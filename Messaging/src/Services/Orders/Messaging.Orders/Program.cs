using MassTransit;
using Messaging.MessageBus;
using Messaging.Orders.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddMassTransit(configurator =>
{
  
    configurator.AddConsumer<ProductPriceDiscountedConsumer>();
    configurator.UsingRabbitMq((context, factoryConfig) =>
    {
        factoryConfig.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        factoryConfig.ConfigureEndpoints(context);
        factoryConfig.ReceiveEndpoint(nameof(ProductPriceDiscountedEvent),c=>c.ConfigureConsumer<ProductPriceDiscountedConsumer>(context));

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
