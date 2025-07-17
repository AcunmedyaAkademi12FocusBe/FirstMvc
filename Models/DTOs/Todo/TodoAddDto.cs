using System.ComponentModel.DataAnnotations;

namespace FirstMvc.Models.DTOs.Todo;

public class TodoAddDto
{
    [Required, MaxLength(200)]
    public required string Task { get; set; }
}