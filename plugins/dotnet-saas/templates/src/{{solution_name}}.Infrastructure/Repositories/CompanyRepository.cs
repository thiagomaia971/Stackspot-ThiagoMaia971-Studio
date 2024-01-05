using CruderSimple.Core.Entities;
using CruderSimple.MySql.Interfaces;
using CruderSimple.MySql.Repositories;
using Microsoft.EntityFrameworkCore;
using {{solution_name}}.Domain.Models;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.Models.Identity;
using {{solution_name}}.Infrastructure.Repositories.Base;

namespace {{solution_name}}.Infrastructure.Repositories;

public class CompanyRepository : Repository<Company>, ICompanyRepository
{

    public CompanyRepository(
        {{solution_name}}DbContext dbContext,
        MultiTenantScoped multiTenant) 
        : base(dbContext, multiTenant)
    {
    }
}