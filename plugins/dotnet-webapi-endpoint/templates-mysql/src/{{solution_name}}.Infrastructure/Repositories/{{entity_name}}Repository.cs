using CruderSimple.Core.Entities;
using CruderSimple.Core.Requests.Base;
using {{solution_name}}.Domain.Models;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Infrastructure.Repositories.Base;

namespace {{solution_name}}.Infrastructure.Repositories;

public class {{entity_name}}Repository : Repository<{{entity_name}}>, I{{entity_name}}Repository
{
    public {{entity_name}}Repository(
        {{solution_name}}DbContext {{solution_name|camelcase}}DbContext, 
        MultiTenantScoped multiTenant) 
        : base({{solution_name|camelcase}}DbContext, multiTenant)
    {
    }
}