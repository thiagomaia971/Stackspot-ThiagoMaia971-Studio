using CruderSimple.Core.Entities;
using CruderSimple.Core.Extensions;
using CruderSimple.Core.Interfaces;
using CruderSimple.MySql.Extensions;
using CruderSimple.MySql.Repositories;
using Microsoft.EntityFrameworkCore;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.Models.Identity;
using {{solution_name}}.Infrastructure.Repositories.Base;

namespace {{solution_name}}.Infrastructure.Repositories;

public class RoleRepository(
    {{solution_name}}DbContext dbContext, 
    MultiTenantScoped multiTenant) 
    : Repository<Role>(dbContext, multiTenant), IRoleRepository
{

    protected override IQueryable<Role> Query(bool isAsNoTracking = false, bool ignoreUser = false)
    {
        return base.Query(isAsNoTracking, ignoreUser)
            .Include(c => c.Permissions)
                .ThenInclude(c => c.Route)
            .Include(c => c.Permissions)
                .ThenInclude(c => c.Role);
    }

    public override IRepositoryBase<Role> Add(Role entity, AutoDetachOptions autoDetach = AutoDetachOptions.BEFORE) 
        => base.Add(entity, AutoDetachOptions.AFTER);

    public override IRepositoryBase<Role> Update(Role entity, AutoDetachOptions autoDetach = AutoDetachOptions.BEFORE) 
        => base.Update(entity, AutoDetachOptions.AFTER);

    public override Task Save(bool withoutTracking = true) 
        => base.Save(true);
}