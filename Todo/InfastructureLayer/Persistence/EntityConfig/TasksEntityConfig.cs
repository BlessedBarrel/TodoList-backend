using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfastructureLayer.Persistence;

public class TasksEntityConfig : IEntityTypeConfiguration<TodoModel>
{
    public void Configure(EntityTypeBuilder<TodoModel> builder)
    {
        builder.HasIndex(x => x.Name)
            .IsUnique();
    }
}