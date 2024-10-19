using System.ComponentModel.DataAnnotations;

namespace MiddleSchool.Homework6.Api.Models;

public class ToDoContainer
{
    /// <summary>
    ///     Todo list
    /// </summary>
    [Required]
    public required IEnumerable<ToDoResponseModel> Todos { get; init; }
}