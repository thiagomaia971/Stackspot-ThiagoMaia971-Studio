using CruderSimple.MySql.Interfaces;
using {{solution_name}}.Domain.Models.Identity;

namespace {{solution_name}}.Domain.Interfaces.Repositories
{
    public interface IMultiTenantRepository<TEntity> : IRepository<TEntity>
        where TEntity : CompanyEntity
    {
    }
}
