using System.ComponentModel.DataAnnotations;

namespace MiddleSchool.Homework6.Api.Models;

public class ToDoResponseModel
{
    /// <summary>
    ///     Todo id
    /// </summary>
    /// <example>d5960222-b48e-4e25-ac11-363c582f9c4d</example>
    [Required]
    public required Guid Id { get; init; }

    /// <summary>
    ///     Todo title
    /// </summary>
    /// <example>To do homework</example>
    [Required]
    public required string Title { get; init; }

    /// <summary>
    ///     Todo description
    /// </summary>
    /// <example>To do middle school homework 6</example>
    [Required]
    public required string Description { get; init; }

    /// <summary>
    ///     Date and time of creation in UTC
    /// </summary>
    /// <example>2024-10-19T10:04:20.985Z</example>
    [Required]
    public required DateTime CreatedAtUtc { get; init; }

    /// <summary>
    ///     Date and time of last update in UTC
    /// </summary>
    /// <example>2024-10-19T15:04:20.985Z</example>
    [Required]
    public required DateTime UpdatedAtUtc { get; init; }
}