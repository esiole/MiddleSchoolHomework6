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
    private readonly string _connectionString;

    public ToDoRepository(IOptions<DatabaseOptions> databaseOptions)
    {
        _connectionString = databaseOptions.Value.ConnectionString;
    }

    public async Task Add(ToDo entity, CancellationToken ct)
    {
        await using var connection = new MySqlConnection(_connectionString);
        await connection.OpenAsync(ct);
        await connection.ExecuteAsync(new CommandDefinition(
            Sql.AddTodo,
            ToDoMapper.ToDataAccess(entity),
            cancellationToken: ct));
    }

    public async Task<IReadOnlyCollection<ToDo>> Get(CancellationToken ct)
    {
        await using var connection = new MySqlConnection(_connectionString);
        await connection.OpenAsync(ct);
        var todos = await connection.QueryAsync<ToDoRecord>(new CommandDefinition(Sql.GetTodos, cancellationToken: ct));

        return todos.Select(ToDoMapper.ToDomain).ToArray();
    }

    public async Task Update(ToDo entity, CancellationToken ct)
    {
        await using var connection = new MySqlConnection(_connectionString);
        await connection.OpenAsync(ct);
        await connection.ExecuteAsync(new CommandDefinition(
            Sql.UpdateTodo,
            ToDoMapper.ToDataAccess(entity),
            cancellationToken: ct));
    }
}