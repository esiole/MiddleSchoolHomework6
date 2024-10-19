using System.ComponentModel.DataAnnotations;
using FluentMigrator;

namespace MiddleSchool.Homework6.Migrator.Configuration;

public class MigrationOptions
{
    public const string ConfigSectionName = "Migration";

    [Required]
    public required MigrationDirection Direction { get; set; }

    public long? Version { get; set; }
}