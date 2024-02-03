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

    protected override IQueryable<User> Query(bool isAsNoTracking = false, bool ignoreUser = false)
    {
        return base.Query(isAsNoTracking, ignoreUser)
            .Include(x => x.{{multitenant_name}})
            .AsNoTracking(isAsNoTracking)
            .Include(x => x.Roles)
                .ThenInclude(x => x.Role)
                    .ThenInclude(x => x.Permissions)
                        .ThenInclude(x => x.Route);
    }

    public async Task<IEnumerable<string>> GetRoles(string UserId) 
        => await DbSet
            .Where(x => x.Id == UserId)
            .Select(x => x.Roles.Select(y => y.Id))
            .FirstOrDefaultAsync();

    public override IRepositoryBase<User> Update(User entity, AutoDetachOptions autoDetach = AutoDetachOptions.BEFORE) 
        => base.Update(entity, AutoDetachOptions.NONE);

    public override Task Save(bool withoutTracking = true) 
        => base.Save(false);
}