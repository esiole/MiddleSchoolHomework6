namespace MiddleSchool.Homework6.DataAccess.Records;

public record ToDoRecord(Guid Id, string Title, string Description, DateTime CreatedAtUtc, DateTime UpdatedAtUtc);