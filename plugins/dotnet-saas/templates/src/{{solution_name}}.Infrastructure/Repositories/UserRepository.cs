using CruderSimple.Core.EndpointQueries;
using CruderSimple.Core.Entities;
using CruderSimple.Core.Extensions;
using CruderSimple.Core.Interfaces;
using CruderSimple.MySql.Extensions;
using CruderSimple.MySql.Interfaces;
using CruderSimple.MySql.Repositories;
using Microsoft.EntityFrameworkCore;
using {{solution_name}}.Domain.EndpointQueries.User;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.Models.Identity;
using {{solution_name}}.Infrastructure.Repositories.Base;

namespace {{solution_name}}.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly IRepository<UserRole> _UserRoleRepository;

    public UserRepository(
        {{solution_name}}DbContext dbContext,
        MultiTenantScoped multiTenant,
        IRepository<UserRole> UserRoleRepository) 
        : base(dbContext, multiTenant)
    {
        _UserRoleRepository = UserRoleRepository;
    }

    public override Task<Pagination<User>> GetAll(GetAllEndpointQuery query = null)
    {
        var userQuery = (UserGetAllQuery) query;
        var queryable = base.Query();
            // .Where(x => userQuery == null || userQuery.name == null || x.Name.ToLower().Contains(userQuery.name.ToLower()));
        return Task.FromResult(queryable.ApplyQuery(userQuery));
    }

    public async Task<IEnumerable<string>> GetRoles(string UserId) 
        => await DbSet
            .Where(x => x.Id == UserId)
            .Select(x => x.Roles.Select(y => y.Id))
            .FirstOrDefaultAsync();
}