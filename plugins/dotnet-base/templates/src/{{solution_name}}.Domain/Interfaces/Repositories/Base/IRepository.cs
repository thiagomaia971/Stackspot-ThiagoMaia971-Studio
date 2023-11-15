using {{solution_name}}.Domain.Models;

namespace {{solution_name}}.Domain.Interfaces.Repositories.Base;

public interface IRepository<T> where T : Entity {
    Task<T> Save(T entity);
    Task<T> FindById(string id);
    Task<IEnumerable<T>> GetAll();
    Task Remove(T entity);
}