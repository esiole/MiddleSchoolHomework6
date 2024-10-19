using MiddleSchool.Homework6.Domain;

namespace MiddleSchool.Homework6.DataAccess;

internal class ToDoRepository : IToDoRepository
{
    private List<ToDo> _store = [];

    public async Task Add(ToDo entity, CancellationToken ct)
    {
        _store.Add(entity);
        await Task.CompletedTask;
    }

    public async Task<IReadOnlyCollection<ToDo>> Get(CancellationToken ct)
    {
        return await Task.FromResult(_store.ToArray());
    }

    public async Task Update(ToDo entity, CancellationToken ct)
    {
        _store = [.._store.Where(s => s.Id != entity.Id), entity];
        await Task.CompletedTask;
    }
}