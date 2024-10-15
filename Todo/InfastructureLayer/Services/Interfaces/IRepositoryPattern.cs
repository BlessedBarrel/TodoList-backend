using System.Linq.Expressions;

namespace InfastructureLayer.Services.interfaces;

public interface IRepositoryPattern<T>
{
    public Task<T?> GetByIdAsync(int id);
    public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    public  Task AddAsync(T TEntity);
    public  Task SaveChangesAsync();
    public  Task<bool> ExistsAsync(Expression<Func<T,bool>> predicate);
    public void UpdatechangesAsync(T TEntity);
    public void Delete(T TEntity);



}