using System.ComponentModel.DataAnnotations;

namespace MiddleSchool.Homework6.Shared.Configuration;

public class DatabaseOptions
{
    public const string ConfigSectionName = "Database";

    [Required]
    public required string ConnectionString { get; set; } = string.Empty;
}