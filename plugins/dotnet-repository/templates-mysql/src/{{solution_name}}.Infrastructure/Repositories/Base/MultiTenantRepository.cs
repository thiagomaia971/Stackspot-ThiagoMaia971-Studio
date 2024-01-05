using CruderSimple.Core.Entities;
using CruderSimple.Core.Interfaces;
using CruderSimple.MySql.Repositories;
using Microsoft.EntityFrameworkCore;
using {{solution_name}}.Domain.Models.Identity;

namespace {{solution_name}}.Infrastructure.Repositories.Base;

public class MultiTenantRepository<TEntity>(DbContext dbContext, MultiTenantScoped multiTenant) : Repository<TEntity>(dbContext, multiTenant)
    where TEntity : {{multitenant_name}}Entity
{
    public override IRepositoryBase<TEntity> Remove(TEntity entity)
    {
        if (string.IsNullOrEmpty(entity.{{multitenant_name}}Id))
            entity.{{multitenant_name}}Id = MultiTenant.Id;
        return base.Remove(entity);
    }

    protected override IQueryable<TEntity> Query() 
        => string.IsNullOrEmpty(MultiTenant.Id) ? 
            base.Query() : 
            base.Query().Where(x => x.{{multitenant_name}}Id == MultiTenant.Id);
}