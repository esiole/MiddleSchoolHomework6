using MiddleSchool.Homework6.DataAccess.Records;
using MiddleSchool.Homework6.Domain;

namespace MiddleSchool.Homework6.DataAccess.Mapping;

internal static class ToDoMapper
{
    internal static ToDoRecord ToDataAccess(ToDo entity)
    {
        return new ToDoRecord(entity.Id, entity.Title, entity.Description, entity.CreatedAtUtc, entity.UpdatedAtUtc);
    }

    internal static ToDo ToDomain(ToDoRecord record)
    {
        return new ToDo
        {
            Id = record.Id,
            Title = record.Title,
            Description = record.Description,
            CreatedAtUtc = record.CreatedAtUtc,
            UpdatedAtUtc = record.UpdatedAtUtc,
        };
    }
}