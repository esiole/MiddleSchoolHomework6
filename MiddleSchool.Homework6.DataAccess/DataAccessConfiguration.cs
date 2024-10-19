using Microsoft.Extensions.DependencyInjection;
using MiddleSchool.Homework6.Domain;

namespace MiddleSchool.Homework6.DataAccess;

public static class DataAccessConfiguration
{
    public static IServiceCollection AddDataAccess(this IServiceCollection builder)
    {
        return builder.AddSingleton<IToDoRepository, ToDoRepository>();
    }
}