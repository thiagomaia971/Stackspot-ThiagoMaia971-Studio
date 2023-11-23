using Amazon.DynamoDBv2.DataModel;
using {{solution_name}}.Domain.Interfaces.Repositories.Base;
using {{solution_name}}.Domain.Models;

namespace {{solution_name}}.Infrastructure.Repositories.Base;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : Entity
{
    protected readonly CustomDbContext _context;

    public Repository(CustomDbContext Context)
    {
        _context = Context;
    }

    public virtual void Add(T entity)
    {
        _context.Add(entity);
    }

    public virtual void Update(T entity)
    {
        _context.Update(entity);
    }

    public virtual void Delete(T entity)
    {
        _context.Remove(entity);
    }

    public virtual async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public virtual IQueryable<T> GetAll()
    {
        return _context.Set<T>();
    }

    public virtual Task<T> GetById(int id) 
        => GetAll().FirstOrDefaultAsync(x => x.Id == id);
}