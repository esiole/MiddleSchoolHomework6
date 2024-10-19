namespace MiddleSchool.Homework6.Api.Models;

public class ToDoContainer
{
    public required IEnumerable<ToDoResponseModel> Todos { get; init; }
}