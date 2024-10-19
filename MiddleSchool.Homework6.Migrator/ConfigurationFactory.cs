using Microsoft.Extensions.Configuration;

namespace MiddleSchool.Homework6.Migrator;

internal static class ConfigurationFactory
{
    internal static IConfiguration Build()
    {
        try
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .AddUserSecrets<Program>(true)
                .Build();
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Building configuration failed with exception: {exception}");
            throw;
        }
    }
}