using FirstMvc.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstMvc.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Todo> Todos { get; set; }
}