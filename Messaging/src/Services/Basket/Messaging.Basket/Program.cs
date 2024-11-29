using MassTransit;
using Messaging.Basket.Consumers;

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
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();



app.Run();

