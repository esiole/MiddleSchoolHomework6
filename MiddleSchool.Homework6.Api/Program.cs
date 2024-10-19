using MiddleSchool.Homework6.Api.Mapping;
using MiddleSchool.Homework6.Api.Models;
using MiddleSchool.Homework6.Application;
using MiddleSchool.Homework6.Application.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMiddleSchoolHomework6();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/todos", async (IToDoService toDoService, CancellationToken ct) =>
    {
        var todos = await toDoService.Get(ct);
        return new ToDoContainer { Todos = todos.Select(ToDoMapper.ToApiModel) };
    })
    .WithOpenApi();

app.MapPost("/todos", async (ToDoRequestModel model, IToDoService toDoService, CancellationToken ct) =>
    {
        await toDoService.Add(ToDoMapper.ToDomain(model), ct);
        return Results.Ok();
    })
    .WithOpenApi();

app.MapPut("/todos/{id:guid}",
        async (Guid id, ToDoRequestModel model, IToDoService toDoService, CancellationToken ct) =>
        {
            await toDoService.Update(ToDoMapper.ToDomain(model, id), ct);
            return Results.Ok();
        })
    .WithOpenApi();

app.Run();