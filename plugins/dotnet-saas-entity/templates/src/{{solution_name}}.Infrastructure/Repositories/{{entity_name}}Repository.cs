using CruderSimple.Core.Entities;
using CruderSimple.MySql.Repositories;
using {{solution_name}}.Domain.Models;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Infrastructure.Repositories.Base;

namespace {{solution_name}}.Infrastructure.Repositories;

public class {{entity_name}}Repository(
    {{solution_name}}DbContext dbContext,
    MultiTenantScoped multiTenant) : Repository<{{entity_name}}>, I{{entity_name}}Repository
{
}