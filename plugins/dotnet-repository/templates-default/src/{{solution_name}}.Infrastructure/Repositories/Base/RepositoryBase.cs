using {{solution_name}}.Domain.Interfaces.Repositories.Base;
using {{solution_name}}.Domain.Models;

namespace {{solution_name}}.Infrastructure.Repositories.Base;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : Entity 
{
    public Task<TEntity> Save(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> FindById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Remove(TEntity entity)
    {
        throw new NotImplementedException();
    }
}