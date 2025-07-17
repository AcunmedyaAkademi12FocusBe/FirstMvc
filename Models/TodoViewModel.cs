using FirstMvc.Models.Entities;

namespace FirstMvc.Models;

public class TodoViewModel
{
    public Todo[] Todos { get; set; }
    public int? TodoId { get; set; }
}