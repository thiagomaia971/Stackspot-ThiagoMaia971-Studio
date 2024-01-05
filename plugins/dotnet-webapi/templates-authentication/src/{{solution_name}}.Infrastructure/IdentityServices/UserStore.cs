using Microsoft.AspNetCore.Identity;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.Models.Identity;

namespace {{solution_name}}.Infrastructure.IdentityServices;

public class UserStore : IUserStore<User>, IUserPasswordStore<User>, IUserEmailStore<User>, IUserRoleStore<User>
{
    private readonly IUserRepository _userRepository;
    //private readonly IRepository<Role> _roleRepository;
    //private readonly IRepository<UserRole> _userRoleRepository;

    public UserStore(
        IUserRepository userRepository/*,
        IRepository<Role> roleRepository,
        IRepository<UserRole> userRoleRepository*/)
    {
        _userRepository = userRepository;
        /*_roleRepository = roleRepository;
        _userRoleRepository = userRoleRepository;*/
    }
    
    public void Dispose()
    {
        //throw new NotImplementedException();
    }

    public Task<string> GetUserIdAsync(User User, CancellationToken cancellationToken) 
        => Task.FromResult(User.Id);

    public Task<string> GetUserNameAsync(User User, CancellationToken cancellationToken)
        => Task.FromResult(User.GetPrimaryKey().ToLower());

    public Task SetUserNameAsync(User User, string userName, CancellationToken cancellationToken)
    {
        // User.GetPrimaryKey() = userName.ToLower();
        return Task.CompletedTask;
    }

    public Task<string> GetNormalizedUserNameAsync(User User, CancellationToken cancellationToken)
        => Task.FromResult(User.GetPrimaryKey().ToLower());

    public Task SetNormalizedUserNameAsync(User User, string normalizedName, CancellationToken cancellationToken)
    {
        // User.GetPrimaryKey() = normalizedName.ToLower();
        return Task.CompletedTask;
    }

    public async Task<IdentityResult> CreateAsync(User User, CancellationToken cancellationToken)
    {
        var defaultRoleId = "0439ac1d-c8aa-4d9b-b7b7-68d5c562eac7";
        //User.Roles.Add(defaultRoleId);
        await _userRepository.Add(User).Save();
        
        return IdentityResult.Success;
    }

    public async Task<IdentityResult> UpdateAsync(User User, CancellationToken cancellationToken)
    {
        //var userDynamo = await _userRepository.Find(user.Id);
        await _userRepository.Update(User).Save();
        return IdentityResult.Success;
    }

    public Task<IdentityResult> DeleteAsync(User User, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken) 
        => await _userRepository.FindById(userId);

    public async Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
{%if is_dynamodb == "true"%}
        var single = await _userRepository.FindBy("PrimaryKey", normalizedUserName.ToLower());
{%else%}
        var single = (await _userRepository.GetAll()).Data.FirstOrDefault(x => x.Email == normalizedUserName.ToLower());
{%endif%}
        return single;
    }

    public Task SetPasswordHashAsync(User User, string passwordHash, CancellationToken cancellationToken)
    {
        User.PasswordHash = passwordHash;
        return Task.CompletedTask;
    }

    public Task<string> GetPasswordHashAsync(User User, CancellationToken cancellationToken) 
        => Task.FromResult(User.PasswordHash);

    public Task<bool> HasPasswordAsync(User User, CancellationToken cancellationToken) 
        => Task.FromResult(!string.IsNullOrEmpty(User.PasswordHash));

    public Task SetEmailAsync(User User, string email, CancellationToken cancellationToken)
    {
        // User.GetPrimaryKey() = email;
        return Task.CompletedTask;
    }

    public Task<string> GetEmailAsync(User User, CancellationToken cancellationToken) 
        => Task.FromResult(User.GetPrimaryKey());

    public Task<bool> GetEmailConfirmedAsync(User User, CancellationToken cancellationToken)
        => Task.FromResult(User.EmailConfirmed);


    public Task SetEmailConfirmedAsync(User User, bool confirmed, CancellationToken cancellationToken)
    {
        User.EmailConfirmed = confirmed;
        return Task.CompletedTask;
    }

    public async Task<User> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
    {
{%if is_dynamodb == "true"%}
        var findByHash = await _userRepository.FindBy("PrimaryKey", normalizedEmail.ToLower());
{%else%}
        var findByHash = (await _userRepository.GetAll()).Data.FirstOrDefault(x => x.Email == normalizedEmail.ToLower());
{%endif%}

        return findByHash;
    }

    public Task<string> GetNormalizedEmailAsync(User User, CancellationToken cancellationToken) 
        => Task.FromResult(User.Id.ToLower());

    public Task SetNormalizedEmailAsync(User User, string normalizedEmail, CancellationToken cancellationToken)
    {
        // User.GetPrimaryKey() = normalizedEmail.ToLower();
        return Task.CompletedTask;
    }

    public Task AddToRoleAsync(User User, string roleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task RemoveFromRoleAsync(User User, string roleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<string>> GetRolesAsync(User User, CancellationToken cancellationToken)
    {
        var result = User.Roles.Select(x => x.RoleId).ToList();
        return result;
        /*var rolesAsync = (await _userRepository.GetRoles(User.Id)).ToList();
        return rolesAsync;*/
    }

    public Task<bool> IsInRoleAsync(User User, string roleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}