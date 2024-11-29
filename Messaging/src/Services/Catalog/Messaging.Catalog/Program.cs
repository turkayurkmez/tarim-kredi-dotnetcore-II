using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddMassTransit(configurator =>
{
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

app.UseAuthorization();

app.MapControllers();

app.Run();
