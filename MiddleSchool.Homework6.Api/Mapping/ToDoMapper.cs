using MiddleSchool.Homework6.Api.Models;
using MiddleSchool.Homework6.Domain;

namespace MiddleSchool.Homework6.Api.Mapping;

internal static class ToDoMapper
{
    internal static ToDoResponseModel ToApiModel(ToDo entity)
    {
        return new ToDoResponseModel
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            CreatedAtUtc = entity.CreatedAtUtc,
            UpdatedAtUtc = entity.UpdatedAtUtc,
        };
    }

    internal static ToDo ToDomain(ToDoRequestModel model, Guid? id = null)
    {
        return new ToDo
        {
            Id = id ?? Guid.NewGuid(),
            Title = model.Title,
            Description = model.Description,
            CreatedAtUtc = DateTime.UtcNow,
            UpdatedAtUtc = DateTime.UtcNow,
        };
    }
}