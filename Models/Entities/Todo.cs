using System.ComponentModel.DataAnnotations;

namespace FirstMvc.Models.Entities;

public class Todo
{
    public int Id { get; set; }
    [MaxLength(200)]
    public required string Task { get; set; }
    public bool Completed { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Updated { get; set; }
}