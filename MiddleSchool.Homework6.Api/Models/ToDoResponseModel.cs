namespace MiddleSchool.Homework6.Api.Models;

public class ToDoResponseModel : ToDoRequestModel
{
    public required Guid Id { get; init; }
}