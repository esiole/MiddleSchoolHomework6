using System.ComponentModel.DataAnnotations;

namespace MiddleSchool.Homework6.Migrator.Configuration;

public class DatabaseOptions
{
    public const string ConfigSectionName = "Database";

    [Required]
    public required string ConnectionString { get; set; } = string.Empty;
}