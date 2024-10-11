using System.Linq.Expressions;

namespace InfastructureLayer.Services.interfaces;

public interface IRepositoryPattern<T>
{
    public Task<T?> GetByIdAsync(int id);
    public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    public  Task AddAsync(T TEntity);
    public  Task SaveChangesAsync();

}