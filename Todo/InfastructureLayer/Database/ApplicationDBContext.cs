using Microsoft.EntityFrameworkCore;
using DomainLayer.Models;

namespace InfastructureLayer.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions dbContextOptions) 
    : base(dbContextOptions)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
    
    public DbSet<TodoModel> Tasks { get; set; }
}