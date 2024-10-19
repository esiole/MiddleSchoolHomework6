using Dapper;
using Microsoft.Extensions.Options;
using MiddleSchool.Homework6.DataAccess.Mapping;
using MiddleSchool.Homework6.DataAccess.Records;
using MiddleSchool.Homework6.DataAccess.Scripts;
using MiddleSchool.Homework6.Domain;
using MiddleSchool.Homework6.Shared.Configuration;
using MySqlConnector;

namespace MiddleSchool.Homework6.DataAccess;

internal class ToDoRepository : IToDoRepository
{
    private readonly DatabaseOptions _databaseOptions;

    public ToDoRepository(IOptions<DatabaseOptions> databaseOptions)
    {
        _databaseOptions = databaseOptions.Value;
    }

    public async Task Add(ToDo entity, CancellationToken ct)
    {
        await using var connection = new MySqlConnection(_databaseOptions.ConnectionString);
        await connection.OpenAsync(ct);
        await connection.ExecuteAsync(new CommandDefinition(
            Sql.AddTodo,
            ToDoMapper.ToDataAccess(entity),
            commandTimeout: _databaseOptions.Timeout,
            cancellationToken: ct));
    }

    public async Task<IReadOnlyCollection<ToDo>> Get(CancellationToken ct)
    {
        await using var connection = new MySqlConnection(_databaseOptions.ConnectionString);
        await connection.OpenAsync(ct);
        var todos = await connection.QueryAsync<ToDoRecord>(new CommandDefinition(
            Sql.GetTodos,
            commandTimeout: _databaseOptions.Timeout,
            cancellationToken: ct));

        return todos.Select(ToDoMapper.ToDomain).ToArray();
    }

    public async Task<ToDo?> GetById(Guid id, CancellationToken ct)
    {
        await using var connection = new MySqlConnection(_databaseOptions.ConnectionString);
        await connection.OpenAsync(ct);
        var todos = await connection.QueryAsync<ToDoRecord>(new CommandDefinition(
            Sql.GetTodoById(id),
            commandTimeout: _databaseOptions.Timeout,
            cancellationToken: ct));

        return todos.Select(ToDoMapper.ToDomain).SingleOrDefault();
    }

    public async Task Update(ToDo entity, CancellationToken ct)
    {
        await using var connection = new MySqlConnection(_databaseOptions.ConnectionString);
        await connection.OpenAsync(ct);
        await connection.ExecuteAsync(new CommandDefinition(
            Sql.UpdateTodo,
            ToDoMapper.ToDataAccess(entity),
            commandTimeout: _databaseOptions.Timeout,
            cancellationToken: ct));
    }
}