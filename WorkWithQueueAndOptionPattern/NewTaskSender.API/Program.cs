using NewTaskSender.API.Services;
using RabbitMQClient.Library;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<RabbitMQConnectionOptions>(builder.Configuration.GetSection("RabbitMQSettings"));

builder.Services.AddSingleton<RabbitMQConnector>();
builder.Services.AddScoped<INewTaskSender, NewTaskSender.API.Services.NewTaskSender>();

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
