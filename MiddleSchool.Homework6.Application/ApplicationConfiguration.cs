using Microsoft.Extensions.DependencyInjection;
using MiddleSchool.Homework6.Application.Abstractions;
using MiddleSchool.Homework6.DataAccess;

namespace MiddleSchool.Homework6.Application;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddMiddleSchoolHomework6(this IServiceCollection builder)
    {
        builder.AddDataAccess();

        builder.AddSingleton<IToDoService, ToDoService>();

        return builder;
    }
}