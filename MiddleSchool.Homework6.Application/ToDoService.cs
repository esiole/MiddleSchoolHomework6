using MiddleSchool.Homework6.Application.Abstractions;
using MiddleSchool.Homework6.Domain;

namespace MiddleSchool.Homework6.Application;

internal class ToDoService(IToDoRepository repository) : IToDoService
{
    public async Task Add(ToDo entity, CancellationToken ct)
    {
        await repository.Add(entity, ct);
    }

    public async Task<IReadOnlyCollection<ToDo>> Get(CancellationToken ct)
    {
        return await repository.Get(ct);
    }

    public async Task Update(ToDo entity, CancellationToken ct)
    {
        await repository.Update(entity, ct);
    }
}