using CruderSimple.Core.Entities;
using CruderSimple.MySql.Interfaces;
using CruderSimple.MySql.Repositories;
using Microsoft.EntityFrameworkCore;
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
    
    public async Task<IEnumerable<string>> GetRoles(string UserId) 
        => await dbSet
            .Where(x => x.Id == UserId)
            .Select(x => x.Roles.Select(y => y.RoleId))
            .FirstOrDefaultAsync();
}