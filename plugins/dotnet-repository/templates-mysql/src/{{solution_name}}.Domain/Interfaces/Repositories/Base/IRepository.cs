using {{solution_name}}.Domain.Models;
using {{solution_name}}.Domain.ViewModels.Base;

namespace {{solution_name}}.Domain.Interfaces.Repositories.Base;

public interface IRepository<T>
    where T : Entity 
{
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<Pagination<T>> GetAll();
        Task<T> GetById(int id);
        Task<bool> SaveChangesAsync();
}