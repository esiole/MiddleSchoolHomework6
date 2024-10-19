using MiddleSchool.Homework6.Domain;

namespace MiddleSchool.Homework6.Application.Abstractions;

public interface IToDoService
{
    Task Add(ToDo entity, CancellationToken ct);
    Task<IReadOnlyCollection<ToDo>> Get(CancellationToken ct);
    Task Update(ToDo entity, CancellationToken ct);
}