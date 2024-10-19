using FluentMigrator;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MiddleSchool.Homework6.Migrator;
using MiddleSchool.Homework6.Migrator.Configuration;

var serviceProvider = ServiceProviderFactory.Build();

using var scope = serviceProvider.CreateScope();
var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

try
{
    var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    var migrationOptions = scope.ServiceProvider.GetRequiredService<IOptions<MigrationOptions>>().Value;

    switch (migrationOptions.Direction)
    {
        case MigrationDirection.Up when migrationOptions.Version == null:
            runner.MigrateUp();
            break;
        case MigrationDirection.Up when migrationOptions.Version != null:
            runner.MigrateUp(migrationOptions.Version.Value);
            break;
        case MigrationDirection.Down when migrationOptions.Version != null:
            runner.MigrateDown(migrationOptions.Version.Value);
            break;
        default:
            throw new ArgumentException("MigrationVersion should be passed for MigrationDirection.Down");
    }
}
catch (Exception exception)
{
    logger.LogCritical(exception, "Migration failed with exception");
    throw;
}