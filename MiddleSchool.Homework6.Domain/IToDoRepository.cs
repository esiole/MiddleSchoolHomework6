namespace MiddleSchool.Homework6.Domain;

public interface IToDoRepository
{
    Task Add(ToDo entity, CancellationToken ct);
    Task<IReadOnlyCollection<ToDo>> Get(CancellationToken ct);
    Task Update(ToDo entity, CancellationToken ct);
}