using System.ComponentModel.DataAnnotations;

namespace MiddleSchool.Homework6.Shared.Configuration;

public class DatabaseOptions
{
    public const string ConfigSectionName = "Database";

    [Required]
    public string ConnectionString { get; set; } = string.Empty;

    public int? Timeout { get; set; }
}