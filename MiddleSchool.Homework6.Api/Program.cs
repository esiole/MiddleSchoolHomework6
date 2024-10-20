using System.Reflection;
using MiddleSchool.Homework6.Api.Mapping;
using MiddleSchool.Homework6.Api.Models;
using MiddleSchool.Homework6.Application;
using MiddleSchool.Homework6.Application.Abstractions;
using MiddleSchool.Homework6.Shared.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddMiddleSchoolHomework6();
builder.Services
    .AddOptions<DatabaseOptions>()
    .Bind(builder.Configuration.GetRequiredSection(DatabaseOptions.ConfigSectionName))
    .ValidateDataAnnotations();

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

app.MapGet("/todos/{id:guid}", async (Guid id, IToDoService toDoService, CancellationToken ct) =>
    {
        var todo = await toDoService.GetById(id, ct);
        return todo == null ? Results.NotFound() : Results.Ok(ToDoMapper.ToApiModel(todo));
    })
    .Produces<ToDoResponseModel>()
    .Produces(StatusCodes.Status404NotFound);

app.MapPost("/todos", async (ToDoRequestModel model, IToDoService toDoService, CancellationToken ct) =>
    {
        var domainModel = ToDoMapper.ToDomain(model);
        await toDoService.Add(domainModel, ct);
        return Results.Created($"/todos/{domainModel.Id}", null);
    })
    .Produces(StatusCodes.Status201Created);

app.MapPut("/todos/{id:guid}",
        async (Guid id, ToDoRequestModel model, IToDoService toDoService, CancellationToken ct) =>
        {
            await toDoService.Update(ToDoMapper.ToDomain(model, id), ct);
            return Results.Ok();
        })
    .WithOpenApi();

app.Run();