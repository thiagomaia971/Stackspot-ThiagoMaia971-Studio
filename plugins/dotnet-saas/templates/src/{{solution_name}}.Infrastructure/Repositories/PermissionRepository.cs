using CruderSimple.Core.Entities;
using CruderSimple.MySql.Repositories;
using Microsoft.EntityFrameworkCore;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.Models.Identity;

namespace {{solution_name}}.Infrastructure.Repositories;

public class PermissionRepository(DbContext dbContext, MultiTenantScoped multiTenant) 
    : Repository<Permission>(dbContext, multiTenant), IPermissionRepository;