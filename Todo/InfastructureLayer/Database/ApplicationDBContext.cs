using Microsoft.EntityFrameworkCore;
using DomainLayer.Models;

namespace InfastructureLayer.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions dbContextOptions) 
    : base(dbContextOptions)
    {

    }
    
    public DbSet<TodoModel> Tasks { get; set; }
}