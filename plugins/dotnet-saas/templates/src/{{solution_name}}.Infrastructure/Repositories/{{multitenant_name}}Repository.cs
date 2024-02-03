using CruderSimple.Core.Entities;
using CruderSimple.Core.Interfaces;
using CruderSimple.MySql.Interfaces;
using CruderSimple.MySql.Repositories;
using Microsoft.EntityFrameworkCore;
using {{solution_name}}.Domain.Models;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.Models.Identity;
using {{solution_name}}.Infrastructure.Repositories.Base;

namespace {{solution_name}}.Infrastructure.Repositories;

public class {{multitenant_name}}Repository(
    {{solution_name}}DbContext dbContext,
    MultiTenantScoped multiTenant) : Repository<{{multitenant_name}}>(dbContext, multiTenant), I{{multitenant_name}}Repository
{    
    public override IRepositoryBase<{{multitenant_name}}> Add({{multitenant_name}} entity, AutoDetachOptions autoDetach = AutoDetachOptions.BEFORE)
    {
        return base.Add(entity, AutoDetachOptions.NONE);
    }

    public override Task Save(bool withoutTracking = true)
    {
        return base.Save(false);
    }
}