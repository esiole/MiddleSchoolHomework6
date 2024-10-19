using System.ComponentModel.DataAnnotations;

namespace MiddleSchool.Homework6.Api.Models;

public class ToDoRequestModel
{
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
    ///     Date of creation in UTC
    /// </summary>
    [Required]
    public required DateOnly CreatedAtUtc { get; init; }

    /// <summary>
    ///     Date of last update in UTC
    /// </summary>
    [Required]
    public required DateOnly UpdatedAtUtc { get; init; }
}