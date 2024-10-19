namespace MiddleSchool.Homework6.Domain;

public class ToDo
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required DateOnly CreatedAtUtc { get; init; }
    public required DateOnly UpdatedAtUtc { get; init; }
}