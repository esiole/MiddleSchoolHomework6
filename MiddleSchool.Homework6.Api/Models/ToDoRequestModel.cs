namespace MiddleSchool.Homework6.Api.Models;

public class ToDoRequestModel
{
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required DateOnly CreatedAtUtc { get; init; }
    public required DateOnly UpdatedAtUtc { get; init; }
}