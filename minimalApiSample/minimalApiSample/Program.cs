using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using minimalApiSample.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TodoDb>(
    option => option.UseInMemoryDatabase(
     "TodoList"
     ));

builder.Services.AddCors(option => option.AddPolicy("allow", configure =>
{
    /*
     * 1. https://www.tarimkredi.org.tr
     * 2. http://www.tarimkredi.org.tr
     * 3. https://accounts.tarimkredi.org.tr
     * 4. http://accounts.tarimkredi.org.tr:8080
     */
    configure.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader();


}));

var app = builder.Build();

app.MapGet("/todos", async (TodoDb db) => await db.Todos.ToListAsync());

app.MapGet("/todos/complete", async (TodoDb db) =>
{
    var completedList = await db.Todos.Where(t => t.IsCompleted).ToListAsync();
    return Results.Ok(completedList);
});

app.MapGet("/todos/{id}", async (int id, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);
    return todo == null ? Results.NotFound() : Results.Ok(todo);

});

app.MapPost("/todos", async (Todo todo, TodoDb db) =>
{
    await db.Todos.AddAsync(todo);
    await db.SaveChangesAsync();
    return Results.Created($"/todos/{todo.Id}", todo);
});

app.MapPut("/todos/{id}", async (int id, Todo todo, TodoDb context) =>
{
    var existingTodo = await context.Todos.FindAsync(id);
    if (existingTodo == null)  return Results.NotFound();

    existingTodo.Name = todo.Name;
    existingTodo.IsCompleted = todo.IsCompleted;
    await context.SaveChangesAsync();
    return Results.NoContent();


});



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("allow");


app.UseHttpsRedirection();





app.Run();

