using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using DynamoDbMapper.Sdk.Entities;
using DynamoDbMapper.Sdk.Interfaces;
using DynamoDbMapper.Sdk.Repositories;
using Test.Domain.Interfaces.Repositories;
using Test.Domain.Models.Identity;

namespace Test.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly IRepository<UserRole> _UserRoleRepository;

    public UserRepository(
        IDynamoDBContext dynamoDbContext,
        MultiTenantScoped multiTenant,
        IRepository<UserRole> UserRoleRepository)
        : base(dynamoDbContext, multiTenant)
    {
        _UserRoleRepository = UserRoleRepository;
    }

    public async Task<IEnumerable<string>> GetRoles(string UserId)
        => (await _UserRoleRepository
            .CreateQuery()
            .ById(UserId)
            .ByEntityType()
            .QueryAsync())
            .Data
            .Select(x => x.RoleId);

}