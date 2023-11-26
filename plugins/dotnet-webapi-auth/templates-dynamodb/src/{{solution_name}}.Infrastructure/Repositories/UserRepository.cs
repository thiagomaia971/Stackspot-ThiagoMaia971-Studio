using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using CruderSimple.Core.Entities;
using CruderSimple.DynamoDb.Interfaces;
using CruderSimple.DynamoDb.Repositories;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.Models.Identity;

namespace {{solution_name}}.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly IRepository<UserRole> _UserRoleRepository;

    public UserRepository(
        IDynamoDBContext dynamoDbContext,
        IAmazonDynamoDB amazonDynamoDb,
        MultiTenantScoped multiTenant,
        IRepository<UserRole> UserRoleRepository) 
        : base(dynamoDbContext, amazonDynamoDb, multiTenant)
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