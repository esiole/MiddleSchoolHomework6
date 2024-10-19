using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiddleSchool.Homework6.Migrator.Configuration;

namespace MiddleSchool.Homework6.Migrator;

internal static class ServiceProviderFactory
{
    internal static IServiceProvider Build()
    {
        var configuration = ConfigurationFactory.Build();

        var connectionString = configuration
            .GetRequiredSection(DatabaseOptions.ConfigSectionName)
            .Get<DatabaseOptions>()
            !.ConnectionString;

        var services = new ServiceCollection();

        services
            .AddOptions<MigrationOptions>()
            .Bind(configuration.GetRequiredSection(MigrationOptions.ConfigSectionName))
            .ValidateDataAnnotations();

        return new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddMySql8()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(typeof(Program).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);
    }
}