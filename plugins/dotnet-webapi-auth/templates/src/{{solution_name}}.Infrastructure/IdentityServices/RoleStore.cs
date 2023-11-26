using CruderSimple.DynamoDb.Interfaces;
using Microsoft.AspNetCore.Identity;
using {{solution_name}}.Domain.Models.Identity;

namespace {{solution_name}}.Infrastructure.IdentityServices;

public class RoleStore : IRoleStore<Role>
{
    private readonly IRepository<Role> _roleRepository;

    public RoleStore(IRepository<Role> roleRepository)
    {
        _roleRepository = roleRepository;
    }
    
    public void Dispose()
    {
        //throw new NotImplementedException();
    }

    public async Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
    {
        await _roleRepository.Save(role);
        return IdentityResult.Success;
    }

    public Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken) 
        => Task.FromResult(role.Id.ToString());

    public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
        => Task.FromResult(role.Name);

    public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
    {
        role.Name = roleName;
        return Task.CompletedTask;
    }

    public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
        => Task.FromResult(role.Name);

    public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
    {
        role.Name = normalizedName;
        return Task.CompletedTask;
    }

    public async Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken) 
        => await _roleRepository.CreateQuery().ById(roleId).FindAsync();

    public Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}