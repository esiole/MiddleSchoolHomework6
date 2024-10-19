using MiddleSchool.Homework6.DataAccess.Records;

namespace MiddleSchool.Homework6.DataAccess.Scripts;

internal static class Sql
{
    internal const string AddTodo = $"""
                                     INSERT INTO todos(Id, Title, Description, CreatedAtUtc, UpdatedAtUtc)
                                     VALUES (@{nameof(ToDoRecord.Id)}, @{nameof(ToDoRecord.Title)}, @{nameof(ToDoRecord.Description)}, @{nameof(ToDoRecord.CreatedAtUtc)}, @{nameof(ToDoRecord.UpdatedAtUtc)});
                                     """;

    internal const string GetTodos = $"""
                                      SELECT Id as {nameof(ToDoRecord.Id)},
                                             Title as {nameof(ToDoRecord.Title)},
                                             Description as {nameof(ToDoRecord.Description)},
                                             CreatedAtUtc as {nameof(ToDoRecord.CreatedAtUtc)},
                                             UpdatedAtUtc as {nameof(ToDoRecord.UpdatedAtUtc)}
                                      FROM todos;
                                      """;

    internal static string GetTodoById(Guid id) => $"""
                                                    SELECT Id as {nameof(ToDoRecord.Id)},
                                                           Title as {nameof(ToDoRecord.Title)},
                                                           Description as {nameof(ToDoRecord.Description)},
                                                           CreatedAtUtc as {nameof(ToDoRecord.CreatedAtUtc)},
                                                           UpdatedAtUtc as {nameof(ToDoRecord.UpdatedAtUtc)}
                                                    FROM todos
                                                    WHERE Id = ('{id}');
                                                    """;

    internal const string UpdateTodo = $"""
                                        UPDATE todos
                                        SET Title = @{nameof(ToDoRecord.Title)},
                                            Description = @{nameof(ToDoRecord.Description)},
                                            UpdatedAtUtc = @{nameof(ToDoRecord.UpdatedAtUtc)}
                                        WHERE Id = @{nameof(ToDoRecord.Id)};
                                        """;
}