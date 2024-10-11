
using System.Linq.Expressions;
using InfastructureLayer.Database;
using InfastructureLayer.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace InfastructureLayer.Repository;

public class RepositoryPattern<T> : IRepositoryPattern<T> where T : class
{
    private readonly ApplicationDbContext context;
    private readonly DbSet<T> dbset;
    public RepositoryPattern(ApplicationDbContext _context)
    {
        context = _context; 
        dbset = context.Set<T>();     
    }
    
    public async Task<T?> GetByIdAsync( int id ) 
    {
        return await dbset.FindAsync(id);
    }
    public async Task<T?> FirstOrDefaultAsync(Expression<Func<T,bool>> predicate )
    {
        return await dbset.FirstOrDefaultAsync(predicate);
    }
    public async Task AddAsync(T TEntity)
    {
        await dbset.AddAsync(TEntity);
    }
    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }

}